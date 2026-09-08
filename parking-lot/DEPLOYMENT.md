# Guía de Deployment con GitHub Container Registry

## Resumen

Este proyecto usa **GitHub Container Registry (ghcr.io)** para almacenar las imágenes Docker. Es gratuito y se integra automáticamente con GitHub.

## ¿Qué se configuró?

### 1. GitHub Actions Workflow (.github/workflows/deploy.yml)
- ✅ Construye automáticamente las imágenes Docker cuando haces push a `main`
- ✅ Las sube a `ghcr.io` (GitHub Container Registry)
- ✅ Usa `GITHUB_TOKEN` automático (no necesitas configurar secretos)
- ✅ Etiqueta las imágenes con: `latest`, nombre de la rama, y SHA del commit

### 2. Dockerfiles
- ✅ Backend: `backend/source/API/Dockerfile` (ya existía)
- ✅ Frontend: `frontend/Dockerfile` (nuevo, creado)

### 3. Docker Compose (deploy.yaml)
- ✅ Actualizado para usar imágenes del registry
- ✅ Mantiene comentadas las opciones de build local

## Pasos para usar

### Paso 1: Hacer push al repositorio

Cuando hagas push a la rama `main`, GitHub Actions automáticamente:
1. Construirá las imágenes Docker
2. Las subirá a GitHub Container Registry

```bash
git add .
git commit -m "Setup Docker registry deployment"
git push origin main
```

### Paso 2: Verificar que las imágenes se subieron

Ve a tu repositorio en GitHub:
- Click en el repositorio → Pestaña "Packages"
- Deberías ver: `backend` y `frontend`

### Paso 3: Hacer las imágenes públicas (opcional)

Por defecto, las imágenes son privadas. Para hacerlas públicas:
1. Ve a "Packages" en tu repositorio
2. Click en cada paquete (`backend` y `frontend`)
3. "Package settings" → "Change visibility" → "Public"

### Paso 4: Deployment en servidor

En tu servidor de producción:

```bash
# 1. Login en GitHub Container Registry (si las imágenes son privadas)
echo $GITHUB_TOKEN | docker login ghcr.io -u USERNAME --password-stdin

# 2. Configura la variable de entorno
export GITHUB_REPOSITORY="username/maneko"  # Reemplaza con tu usuario/repo

# 3. Pull y ejecuta con docker-compose
docker-compose -f deploy.yaml pull
docker-compose -f deploy.yaml up -d
```

## URLs de las imágenes

Una vez publicadas, tus imágenes estarán en:
- **Backend**: `ghcr.io/tu-usuario/maneko/backend:latest`
- **Frontend**: `ghcr.io/tu-usuario/maneko/frontend:latest`

## Desarrollo Local

Para desarrollo local, puedes seguir usando build local:

```bash
# Opción 1: Docker compose con build local
docker-compose up --build

# Opción 2: Descomentar las secciones "build" en deploy.yaml
```

## Crear Personal Access Token (si es necesario)

Si necesitas un token personal (para CI/CD externo o acceso desde otro servidor):

1. GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)
2. "Generate new token"
3. Permisos necesarios:
   - ✅ `write:packages`
   - ✅ `read:packages`
   - ✅ `delete:packages` (opcional)
4. Copia el token
5. Login desde tu servidor:
   ```bash
   echo $TOKEN | docker login ghcr.io -u USERNAME --password-stdin
   ```

## Troubleshooting

### Error: "permission denied"
- Verifica que el workflow tenga permisos: `permissions: packages: write`
- Ya está configurado en el workflow ✅

### Error: "image not found"
- Verifica que el workflow se ejecutó exitosamente en "Actions"
- Verifica el nombre del repositorio en la variable `GITHUB_REPOSITORY`

### Las imágenes son muy grandes
- Considera usar `.dockerignore` para excluir archivos innecesarios
- Ya existe `.dockerignore` en el backend ✅

## Alternativas a GitHub Container Registry

Si prefieres usar otro registry:
- **Docker Hub**: Gratuito con limitaciones, público por defecto
- **Azure Container Registry**: Si usas Azure
- **AWS ECR**: Si usas AWS
- **Google Container Registry**: Si usas GCP

## Próximos pasos (opcional)

- [ ] Configurar semantic versioning para tags
- [ ] Agregar tests antes del build
- [ ] Configurar deployment automático a producción
- [ ] Agregar health checks en docker-compose
- [ ] Configurar certificate SSL/TLS para producción
