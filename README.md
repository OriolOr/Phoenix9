# Phoenix-9

Maneko is a personal finance management web application. It allows you to view monthly balances, manage mortgages, and consult account and stock information. The project consists of a React frontend and a .NET 7 backend, using MongoDB as the database.

---
## Requirements

- Docker and Docker Compose🐋
- Node.js (for frontend development)🍃
- .NET 8 SDK (for backend development)
- MongoDB (automatically started with Docker Compose)


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

### Docker compose 

From deploy directory:
```bash
docker-compose -f deploy.yaml up -d
```

This will start the following services:
- **mongo**: MongoDB database on port 27017
- **frontend**: React app on port 8080
- **backend**: .NET API on port 5000
