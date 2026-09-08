# Recomendación de Base de Datos para phx9

> Análisis orientado al dominio actual de la aplicación: gestión de cuentas bancarias,
> historial de balances por mes/año, hipotecas y credenciales de usuario.

---

## Situación actual

El proyecto usa **MongoDB** como único almacén de datos (`MongoDbConfigurator`).  
Esto funciona para un prototipo, pero presenta riesgos en un contexto bancario real:

| Aspecto | MongoDB | Problema concreto |
|---|---|---|
| Transacciones ACID | Soporte parcial (multi-doc desde v4) | Más complejo de garantizar que en SQL |
| Integridad referencial | No nativa | Balances huerfanos, cuentas inconsistentes |
| Consistencia numérica | `float` / `double` en dominio | Errores de punto flotante en saldos |
| Auditoría | No integrada | Difícil cumplir normativas financieras |

---

## Recomendación: arquitectura de dos capas

### Capa 1 — Core financiero → PostgreSQL

**Por qué PostgreSQL:**

- Transacciones ACID completas y probadas en banca desde hace décadas.
- Soporte nativo de `NUMERIC(precision, scale)`, el tipo correcto para dinero (evita errores de punto flotante que `float`/`double` introducen).
- Integridad referencial con `FOREIGN KEY`, imposible tener un balance sin cuenta padre.
- `SERIALIZABLE` isolation level para evitar race conditions en actualizaciones de saldo.
- Extensión `pgaudit` para log de auditoría inmutable (requisito regulatorio).
- Coste cero, open source, con soporte enterprise comercial disponible (EDB, Supabase, Azure Database for PostgreSQL, etc.).

**Esquema orientativo para el dominio actual:**

```sql
-- Usuarios y autenticación
CREATE TABLE users (
    id          UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    username    TEXT NOT NULL UNIQUE,
    email       TEXT NOT NULL UNIQUE,
    created_at  TIMESTAMPTZ NOT NULL DEFAULT now()
);

CREATE TABLE user_credentials (
    user_id     UUID PRIMARY KEY REFERENCES users(id) ON DELETE CASCADE,
    hash        TEXT NOT NULL,          -- bcrypt/argon2, nunca MD5/SHA1 sin salt
    updated_at  TIMESTAMPTZ NOT NULL DEFAULT now()
);

-- Cuentas bancarias
CREATE TABLE accounts (
    id                  UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id             UUID NOT NULL REFERENCES users(id),
    account_number_id   TEXT NOT NULL UNIQUE,
    current_balance     NUMERIC(18, 4) NOT NULL DEFAULT 0,   -- ← NUMERIC, no float
    last_update         TIMESTAMPTZ NOT NULL DEFAULT now()
);

-- Historial por año
CREATE TABLE year_balances (
    id          SERIAL PRIMARY KEY,
    account_id  UUID NOT NULL REFERENCES accounts(id) ON DELETE CASCADE,
    year        SMALLINT NOT NULL,
    UNIQUE (account_id, year)
);

-- Historial por mes
CREATE TABLE month_balances (
    id              SERIAL PRIMARY KEY,
    year_balance_id INT NOT NULL REFERENCES year_balances(id) ON DELETE CASCADE,
    month           SMALLINT NOT NULL CHECK (month BETWEEN 1 AND 12),
    initial_balance NUMERIC(18, 4) NOT NULL,
    final_balance   NUMERIC(18, 4) NOT NULL,
    UNIQUE (year_balance_id, month)
);

-- Hipotecas
CREATE TABLE home_mortgages (
    id                  UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id             UUID NOT NULL REFERENCES users(id),
    total_mortgage      NUMERIC(18, 4) NOT NULL,
    remaining_mortgage  NUMERIC(18, 4) NOT NULL,
    total_savings       NUMERIC(18, 4) NOT NULL,
    house_value         NUMERIC(18, 4) NOT NULL,
    tax_percentage      NUMERIC(5, 4) NOT NULL   -- ej. 0.0650 = 6.5%
);
```

> **Nota:** Los campos `float`/`double`/`int` del dominio actual (`HomeMortage`, `MonthBalance`)
> deben migrarse a `decimal` en C# y `NUMERIC` en SQL para evitar pérdidas de precisión.

---

### Capa 2 — Caché y sesión → Redis

**Por qué Redis:**

- Almacenamiento de tokens JWT/sesión con TTL automático.
- Rate limiting por usuario (protección contra fuerza bruta en login).
- Bloqueos distribuidos si en el futuro hay múltiples instancias de la API.
- Caché de balances leídos frecuentemente (lectura rápida sin consultar PostgreSQL en cada request).

Redis **no** sustituye a PostgreSQL; es un acelerador y gestor de estado efímero.

---

## ¿Qué pasa con MongoDB?

MongoDB puede mantenerse para casos concretos no críticos:

| Uso válido | Uso a evitar |
|---|---|
| Logs de actividad / eventos de auditoría en append-only | Saldos y transacciones financieras |
| Notificaciones y mensajes al usuario | Datos con relaciones complejas |
| Configuración de preferencias de UI | Cualquier dato que requiera joins precisos |

Si se descarta MongoDB completamente, los logs de auditoría pueden cubrirse con una tabla `audit_log` append-only en PostgreSQL o con una solución externa (Elasticsearch, Loki).

---

## Comparativa resumen

| | MongoDB (actual) | PostgreSQL | Redis |
|---|:---:|:---:|:---:|
| Transacciones ACID | Parcial | ✅ Completo | ❌ |
| Integridad referencial | ❌ | ✅ | ❌ |
| Tipo `NUMERIC` para dinero | ❌ | ✅ | ❌ |
| Escalado horizontal | ✅ | Moderado | ✅ |
| Ideal para caché/sesión | ❌ | ❌ | ✅ |
| Coste operativo | Bajo | Bajo | Bajo |
| Madurez en banca | Bajo-medio | Muy alto | Alto |

---

## Plan de migración sugerido (sin romper lo existente)

1. **Añadir PostgreSQL** como segundo almacén — sin tocar MongoDB todavía.
2. **Paralelizar escrituras**: escribir en ambas BDs durante un periodo de validación.
3. **Migrar lecturas** entidad por entidad (`Account` → `MonthBalance` → `YearBalance` → `HomeMortage`).
4. **Reemplazar `float`/`double`/`int`** en el dominio C# por `decimal` en los modelos financieros.
5. **Desacoplar MongoDB** y usarlo solo para logs/eventos si se desea.
6. **Añadir Redis** para sesión y rate limiting en `UserCredentialsService`.

---

## Stack tecnológico recomendado (con el ecosistema .NET actual)

```
API (.NET)
 ├── EF Core + Npgsql    → PostgreSQL (core bancario)
 ├── StackExchange.Redis → Redis (caché, sesión, rate limiting)
 └── MongoDB.Driver      → MongoDB (logs, eventos — opcional)
```

Referencias:
- [Npgsql - EF Core Provider for PostgreSQL](https://www.npgsql.org/efcore/)
- [StackExchange.Redis](https://stackexchange.github.io/StackExchange.Redis/)
- [PostgreSQL NUMERIC type](https://www.postgresql.org/docs/current/datatype-numeric.html)
- [pgaudit - PostgreSQL Audit Extension](https://github.com/pgaudit/pgaudit)
