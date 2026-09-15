# Phoenix-9

Maneko is a personal finance management web application. It allows you to view monthly balances, manage mortgages, and consult account and stock information. The project consists of a React frontend and a .NET 8 backend.

---
## Requirements

- Podman and Podman Compose (or Docker Compose)
- Node.js (for frontend development)🍃
- .NET 8 SDK (for backend development)


## Backend 

### Build API Dockerimage 

```bash
docker build -f "source/API/Dockerfile" .
```


## Frontend

### Local development

1. Install dependencies:
    ```bash
    cd frontend
    npm install
    ```
2. Start the development server:
    ```bash
    npm start
    ```
3. Access [http://localhost:8080](http://localhost:8080)

### Compose

From the repository root:
```bash
podman compose -f compose.yaml up --build --detach
```

This starts the following services:
- **frontend**: React app on port 8080
- **backend**: .NET API on port 5000
