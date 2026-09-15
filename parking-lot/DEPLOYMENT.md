# Guía de CI y despliegue local

## Resumen

GitHub Actions valida y compila el frontend y el backend. El despliegue local se realiza con Compose usando builds locales.

## ¿Qué se configuró?

### 1. GitHub Actions Workflow (.github/workflows/ci.yml)
- ✅ Comprueba y compila el frontend cuando haces push o pull request a `main`
- ✅ Comprueba y compila el backend cuando haces push o pull request a `main`
- ✅ Usa Node.js 24 y .NET 8

### 2. Dockerfiles
- ✅ Backend: `backend/source/API/Dockerfile` (ya existía)
- ✅ Frontend: `frontend/Dockerfile` (nuevo, creado)

### 3. Compose (compose.yaml)
- ✅ Construye las imágenes localmente
- ✅ Compatible con Podman Compose y Docker Compose
- ✅ Incluye únicamente frontend y backend

## Pasos para usar

## Desarrollo Local

```bash
podman compose -f compose.yaml up --build --detach
```

## Troubleshooting

### Error: "GITHUB_REPOSITORY variable is not set"
- Comprueba que `compose.yaml` usa `build` local y no referencias a `ghcr.io`.
- Ejecuta el comando desde la raíz del repositorio.

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

- [ ] Agregar tests antes del build
- [ ] Agregar health checks en Compose
- [ ] Configurar certificate SSL/TLS para producción
