# Advanced Microservices with .NET & Azure

A cloud-ready microservices solution built with **ASP.NET Core, C#, RabbitMQ, MassTransit, Azure Service Bus, and Microsoft Azure**.

This project explores the design, development, integration, and deployment of distributed applications using modern .NET technologies and microservices architectural patterns.

It demonstrates how independently deployable services communicate through synchronous HTTP requests and asynchronous event-driven messaging while maintaining separation of concerns, security, scalability, and maintainability.

---

## Overview

The objective of this project is to develop a distributed application using **Microservices Architecture** and explore the engineering practices required to build and deploy cloud-ready .NET applications.

The solution focuses on service independence, inter-service communication, centralized API routing, authentication, authorization, asynchronous messaging, caching, and automated deployment.

It also explores how Microsoft Azure services can be integrated into a distributed .NET environment.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# / .NET | Application development |
| ASP.NET Core Web API | Microservice development |
| Entity Framework Core | Data access and ORM |
| SQL Server | Relational data storage |
| RabbitMQ | Message broker |
| MassTransit | Distributed messaging abstraction |
| Azure Service Bus | Cloud-based messaging |
| Ocelot API Gateway | API routing and gateway authorization |
| MediatR | CQRS and request handling |
| FluentValidation | Request validation |
| Redis | Distributed caching |
| SendGrid | Email notifications |
| JWT | Authentication and authorization |
| Swagger / OpenAPI | API documentation |
| Postman | API testing and automation |
| Docker | Containerization |
| Azure App Service | Cloud application hosting |
| Azure DevOps | CI/CD and release automation |
| Azure SQL | Cloud relational database |

---

## Architecture

The application follows a distributed microservices architecture in which individual services are responsible for specific business capabilities.

Services communicate using two primary approaches:

**Synchronous Communication**
- HTTP-based REST API communication.
- API Gateway routing through Ocelot.
- Service-to-service communication.
- Centralized request authorization.

**Asynchronous Communication**
- Event-driven communication using RabbitMQ.
- Message publishing and consumption with MassTransit.
- Azure Service Bus topics and subscriptions.
- Decoupled communication between services.

### High-Level Architecture

```text
                  CLIENT APPLICATION
                         |
                         |
                  OCELOT API GATEWAY
                         |
          +--------------+--------------+
          |              |              |
          v              v              v
      SERVICE A      SERVICE B      SERVICE C
          |              |              |
          v              v              v
       DATABASE       DATABASE       DATABASE
          |              |              |
          +--------------+--------------+
                         |
                  MESSAGE BROKER
                         |
                +--------+--------+
                |                 |
             RabbitMQ        Azure Service Bus
                |                 |
                +--------+--------+
                         |
                  EVENT CONSUMERS
```

*Illustrative architecture showing the major components and communication patterns.*

---

## Key Features

### 1. Microservices Architecture
- Independently developed application services.
- Separation of business responsibilities.
- Service-to-service communication.
- Maintainable and modular application structure.

### 2. Event-Driven Communication
- Asynchronous messaging using RabbitMQ.
- Message publishing and consumption with MassTransit.
- Azure Service Bus topics and subscriptions.
- Loosely coupled distributed services.

### 3. Authentication & Authorization
- JWT token generation and validation.
- Secure authentication across services.
- Role-based authorization.
- Multi-level permission checks.
- API Gateway authorization.

### 4. API Gateway
- Centralized API entry point using Ocelot.
- Request routing to individual microservices.
- Gateway-level authorization.
- Simplified client-to-service communication.

### 5. CQRS & Request Processing
- Command Query Responsibility Segregation (CQRS).
- Request handling with MediatR.
- Custom pipeline behaviors.
- Request validation using FluentValidation.
- Separation of application concerns.

### 6. Caching & Performance
- Redis distributed caching.
- Cache-Aside design pattern.
- Improved API response performance.
- Reduced unnecessary database queries.

### 7. Shared Libraries & NuGet Packages
- Reusable shared application components.
- Custom NuGet package development.
- Centralized shared logic.
- Consistent implementation across services.

### 8. Cross-Cutting Concerns
- Centralized logging.
- Exception handling.
- Request validation.
- Service availability and offline handling.
- Consistent API responses.

### 9. Email Notifications
- SendGrid integration.
- Email notification workflows.
- Integration with distributed application services.

---

## Cloud Deployment & DevOps

The project explores deploying distributed .NET applications to Microsoft Azure and automating delivery workflows using Azure DevOps.

### Microsoft Azure
- Azure App Service for hosting microservices.
- Azure SQL for relational database hosting.
- Azure Cache for Redis.
- Azure Service Bus for asynchronous messaging.
- App Service environment variable configuration.
- Cloud application configuration.

### Azure DevOps
- Automated build pipelines.
- CI/CD pipeline configuration.
- Azure Artifacts for package management.
- Release pipelines.
- Automated application deployment.

### Deployment Workflow

```text
       DEVELOPER
           |
           v
      SOURCE CODE
           |
           v
      AZURE REPOS
           |
           v
      BUILD PIPELINE
           |
           v
      AUTOMATED TESTS
           |
           v
      AZURE ARTIFACTS
           |
           v
      RELEASE PIPELINE
           |
           v
      AZURE APP SERVICE
           |
           v
    DEPLOYED MICROSERVICES
```

---

## Project Structure

The following is an illustrative structure for organizing the solution. Actual directories may differ depending on the implementation.

```text
AdvancedMicroservices/
│
├── ApiGateway/
│   └── ApiGateway/
│
├── Services/
│   ├── ServiceA/
│   │   ├── API/
│   │   ├── Application/
│   │   ├── Domain/
│   │   └── Infrastructure/
│   │
│   ├── ServiceB/
│   │   ├── API/
│   │   ├── Application/
│   │   ├── Domain/
│   │   └── Infrastructure/
│   │
│   └── ServiceC/
│       ├── API/
│       ├── Application/
│       ├── Domain/
│       └── Infrastructure/
│
├── BuildingBlocks/
│   └── SharedLibraries/
│
├── Messaging/
│   ├── RabbitMQ/
│   └── AzureServiceBus/
│
├── Tests/
│
├── docker-compose.yml
├── README.md
└── .gitignore
```

---

## Getting Started

### Prerequisites

- .NET SDK compatible with the solution.
- Visual Studio, JetBrains Rider, or Visual Studio Code.
- SQL Server or Azure SQL.
- Docker Desktop or Docker Engine.
- RabbitMQ.
- Redis.
- Postman.
- Azure account (for cloud deployment exercises).

### 1. Clone the Repository

```bash
git clone <YOUR_REPOSITORY_URL>
cd AdvancedMicroservices
```

### 2. Configure Application Settings

Configure the required connection strings, messaging endpoints, JWT settings, Redis configuration, and external service credentials.

Use environment variables or .NET User Secrets for sensitive configuration.

### 3. Start Infrastructure Dependencies

If Docker Compose is configured:

```bash
docker compose up -d
```

### 4. Restore Dependencies

```bash
dotnet restore
```

### 5. Build the Solution

```bash
dotnet build
```

### 6. Run the Services

Run the individual microservices and API Gateway according to their project configurations.

### 7. Explore API Documentation

Open the Swagger UI endpoint configured for each API service.

Use Postman collections to test service communication, authentication, authorization, and messaging workflows.

---

## Engineering Concepts Demonstrated

This project provides practical exposure to:

- Distributed systems architecture.
- Microservices design principles.
- Synchronous and asynchronous communication.
- Event-driven architecture.
- Message brokers and message consumers.
- API Gateway patterns.
- Authentication and authorization.
- CQRS and MediatR.
- Clean Architecture.
- Distributed caching.
- Database integration.
- Shared library development.
- Cloud-native application deployment.
- CI/CD automation.
- Application reliability and fault handling.

---

## Future Improvements

Potential enhancements for taking the solution further:

- [ ] Implement distributed tracing with OpenTelemetry.
- [ ] Integrate centralized observability.
- [ ] Implement health checks for all services.
- [ ] Add retry policies and circuit breakers using Polly.
- [ ] Implement transactional outbox and inbox patterns.
- [ ] Introduce idempotent message processing.
- [ ] Implement distributed workflow orchestration.
- [ ] Add comprehensive unit and integration tests.
- [ ] Containerize all microservices.
- [ ] Introduce Infrastructure as Code using Terraform.
- [ ] Implement Azure Key Vault integration.
- [ ] Improve automated deployment and rollback strategies.

---

## Author

**Thabang Rakgoropo**

Full-Stack Software Developer | C# | .NET | ASP.NET Core | React | TypeScript | Azure

Interested in designing, developing, and deploying secure, scalable business applications using modern software engineering practices.

**GitHub:** https://github.com/PLThabangR

**LinkedIn:** https://www.linkedin.com/in/ttrakgoropo/

---

## License

This project is intended for educational, professional development, and portfolio purposes.
