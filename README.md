# Advanced Microservices with .NET – Development & Azure Deployment

A practical software engineering project focused on designing, developing, securing, and deploying distributed applications using **C#, ASP.NET Core, Microservices Architecture, messaging systems, and Microsoft Azure**.

This repository documents my implementation and learning journey through the Udemy course:

**Advanced Microservices with .NET: Development & Azure Deploy**

The project explores modern backend engineering practices, distributed system communication, authentication and authorization, reusable NuGet packages, performance optimization, automated testing, and cloud deployment.

---


## 🎯 Objectives

The primary objective is to develop practical skills in building secure, scalable, maintainable, and cloud-ready distributed applications.

Key learning areas include:

- Understanding microservices architecture and distributed systems.
- Implementing event-driven and synchronous communication.
- Building message-driven applications using RabbitMQ, MassTransit, and Azure Service Bus.
- Implementing authentication and multi-level authorization.
- Managing application roles, claims, and permissions.
- Generating and validating JWT authentication tokens.
- Applying CQRS and MediatR design patterns.
- Implementing request validation and custom pipeline behaviours.
- Building reusable NuGet packages.
- Implementing API Gateway routing and authorization using Ocelot.
- Applying caching strategies using Redis.
- Implementing email notifications using SendGrid.
- Applying Clean Architecture principles.
- Managing SQL databases and Entity Framework Core.
- Documenting REST APIs using Swagger UI.
- Creating professional Postman collections and scripts.
- Automating builds and deployments using Azure DevOps.
- Publishing packages through Azure Artifacts.
- Deploying microservices to Azure Web Apps.
- Configuring Azure App Service environment variables.
- Implementing service reliability and offline-service handling.

---

## 🛠️ Technology Stack

The following technologies and tools are explored throughout the project.

### Backend Development

| Technology                           | Purpose                         |
| ------------------------------------ | ------------------------------- |
| C#                                   | Primary programming language    |
| .NET / ASP.NET Core                  | Backend application development |
| ASP.NET Core Web API                 | RESTful API development         |
| Entity Framework Core                | Database access and ORM         |
| MediatR                              | CQRS and request handling       |
| FluentValidation / Custom Validation | Request validation              |

### Microservices & Messaging

| Technology                 | Purpose                                 |
| -------------------------- | --------------------------------------- |
| Microservices Architecture | Distributed application design          |
| MassTransit                | Message-based communication abstraction |
| RabbitMQ                   | Message broker                          |
| Exchanges & Queues         | Message routing and delivery            |
| Azure Service Bus          | Cloud messaging infrastructure          |
| Topics & Subscriptions     | Publish/subscribe messaging             |
| Ocelot                     | API Gateway and routing                 |

### Security & Identity

| Technology                 | Purpose                      |
| -------------------------- | ---------------------------- |
| ASP.NET Core Identity      | User and role management     |
| JWT                        | Token-based authentication   |
| Claims-based Authorization | Identity and access control  |
| Role-based Authorization   | Access management            |
| Custom NuGet Libraries     | Reusable security components |

### Database & Performance

| Technology                 | Purpose                              |
| -------------------------- | ------------------------------------ |
| SQL Server / SQL Databases | Relational data storage              |
| Entity Framework Core      | Data persistence                     |
| Azure Cache for Redis      | Distributed caching                  |
| Cache-Aside Pattern        | Application performance optimization |
| Database Migrations        | Database schema management           |

### Cloud & DevOps

| Technology                              | Purpose                               |
| --------------------------------------- | ------------------------------------- |
| Microsoft Azure                         | Cloud infrastructure                  |
| Azure DevOps                            | Source control and project management |
| Azure Repos                             | Git repository management             |
| Azure Pipelines                         | Continuous Integration and Deployment |
| Azure Artifacts                         | NuGet package management              |
| Azure Web Apps                          | Application hosting                   |
| Azure App Service Environment Variables | Cloud configuration                   |
| Azure Releases                          | Deployment automation                 |

### Development & API Tools

| Technology    | Purpose                           |
| ------------- | --------------------------------- |
| Visual Studio | Development environment           |
| Git           | Version control                   |
| NuGet         | Dependency and package management |
| Swagger UI    | API documentation                 |
| Postman       | API testing and automation        |
| SendGrid      | Email notification services       |

---

## 🏗️ Architecture & Design Patterns

This project explores several architectural approaches and design patterns used in modern enterprise applications.

### 1. Microservices Architecture

Designing applications as independently developed and deployable services with clearly defined responsibilities.

Key concepts:

- Service boundaries.
- Independent service deployment.
- Service-to-service communication.
- Distributed data management.
- Service reliability.
- Fault handling.

### 2. Communication Patterns

**Synchronous communication**

Services communicate directly through HTTP-based APIs and REST endpoints.

**Asynchronous communication**

Services exchange messages through messaging infrastructure.

Technologies explored:

- RabbitMQ
- MassTransit
- Azure Service Bus

### 3. CQRS – Command Query Responsibility Segregation

Separating operations that modify application state from operations that retrieve information.

Implemented using MediatR and request-handling patterns.

### 4. Cache-Aside Pattern

Improving application performance by retrieving frequently accessed information from Redis before querying the underlying database.

### 5. API Gateway Pattern

Using Ocelot to provide a central entry point for client requests, routing requests to appropriate microservices and applying gateway-level authorization.

### 6. Clean Architecture

Organizing application responsibilities to improve maintainability, testability, and separation of concerns.

---

## 🔐 Authentication & Authorization

Security is an important part of the project.

The identity and authorization implementation explores:

- Application user management.
- Application role management.
- Role claims.
- Permission-based authorization.
- JWT generation.
- JWT validation.
- Multi-level authorization checks.
- Reusable authentication and authorization libraries.

### AuthLibrary

A reusable class library developed to centralize shared authentication and authorization functionality.

Its intended responsibilities include:

- Permission definitions.
- Claim definitions.
- Authorization requirements.
- Custom authorization handlers.
- Reusable permission-based authorization components.

The library is designed to be packaged and distributed through NuGet, allowing other applications and microservices to reuse shared security functionality.

---

## 📦 NuGet Package Management

The project explores creating and managing reusable NuGet packages.

The AuthLibrary component provides an opportunity to understand:

1. Developing reusable .NET class libraries.
2. Configuring NuGet package metadata.
3. Managing semantic package versions.
4. Building and packing NuGet packages.
5. Publishing packages to Azure Artifacts.
6. Consuming reusable packages in other .NET applications.

---

## ⚙️ CI/CD – Azure DevOps

Azure DevOps is used to manage source code, automate builds, publish packages, and prepare applications for cloud deployment.

### Continuous Integration (CI)

The build pipeline is designed to automate:

- .NET SDK installation.
- NuGet dependency restoration.
- Solution compilation.
- Unit testing.
- NuGet package generation.
- Publishing packages to Azure Artifacts.

### Continuous Deployment (CD)

The deployment workflow explores:

- Azure service configuration.
- Application deployment to Azure Web Apps.
- Environment variable configuration.
- Release automation.
- Cloud application integration.

---

## 📂 Repository Structure

The repository structure will evolve as the implementation progresses.

```text
Advanced-Microservices-DotNet/
│
├── AuthLibrary/
│   ├── AuthLibrary.csproj
│   └── ...
│
├── IdentityService/
│   └── ...
│
├── Services/
│   └── ...
│
├── ApiGateway/
│   └── ...
│
├── Tests/
│   └── ...
│
├── docs/
│   ├── architecture.md
│   └── implementation-notes.md
│
├── azure-pipelines.yml
│
└── README.md
```

*The structure is illustrative and will be adjusted to match the actual implementation.*

---

## 💻 Development Environment

The project is developed using a Microsoft development environment.

### Prerequisites

- Windows 11.
- Visual Studio 2022.
- Compatible .NET SDK.
- SQL Server.
- SQL Server Management Studio.
- Git.
- Azure DevOps account.
- Microsoft Azure account.
- Postman.

### Clone the Repository

```bash
git clone <YOUR-REPOSITORY-URL>
```

Navigate to the repository:

```bash
cd Advanced-Microservices-DotNet
```

Restore dependencies:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build --configuration Release
```

Run automated tests:

```bash
dotnet test
```

*Note: Commands should be executed from the appropriate solution or project directory.*

---

## 📚 Learning Progress

This repository is being developed incrementally while following the course.

Progress is tracked to document the practical implementation of each major concept.

- [ ] Microservices Architecture Review
- [ ] Project Requirements and Architecture
- [ ] Application Roles and Role Claims
- [ ] Database Context Implementation
- [ ] Database Table Configurations
- [ ] Configuration Registration from Assemblies
- [ ] Dependency Injection – DbContext
- [ ] Entity Framework Core Migrations
- [ ] Identity Models
- [ ] User Registration
- [ ] Role and Permission Management
- [ ] JWT Authentication and Validation
- [ ] Authorization and Permission Checks
- [ ] Custom Authentication Library
- [ ] NuGet Package Creation and Publishing
- [ ] CQRS Implementation
- [ ] MediatR Request Handling
- [ ] Custom Validation Pipeline Behaviours
- [ ] Ocelot API Gateway
- [ ] Synchronous Microservices Communication
- [ ] RabbitMQ Integration
- [ ] MassTransit Integration
- [ ] Azure Service Bus Integration
- [ ] Event-Driven Communication
- [ ] Redis Distributed Caching
- [ ] Cache-Aside Pattern
- [ ] SendGrid Email Notifications
- [ ] Swagger API Documentation
- [ ] Postman Collections and Scripts
- [ ] Service Reliability and Offline Handling
- [ ] Azure DevOps CI/CD Pipelines
- [ ] Azure Artifacts
- [ ] Azure Web Apps Deployment
- [ ] Azure Environment Configuration
- [ ] Cloud Deployment and Integration

---

## 🧪 Testing & API Documentation

The project also explores professional API development and testing practices.

Areas of focus:

- REST API testing using Postman.
- Postman collections and automation scripts.
- API documentation using Swagger UI.
- Request validation.
- Authentication and authorization testing.
- Service communication testing.
- Application build and test automation.

---

## ☁️ Cloud Deployment Goals

The ultimate goal is to understand how to move microservices from local development environments into Microsoft Azure.

Deployment objectives include:

- Configuring cloud-hosted applications.
- Deploying services to Azure Web Apps.
- Managing application configuration.
- Connecting applications to SQL databases.
- Integrating Azure Service Bus.
- Configuring cloud-based caching.
- Automating deployment through Azure DevOps.
- Managing application releases and versions.

---

## 📈 Expected Outcomes

By completing the practical implementation, I aim to develop stronger engineering capabilities in:

1. Designing distributed applications using microservices architecture.
2. Developing secure backend services with ASP.NET Core.
3. Implementing event-driven and asynchronous communication.
4. Managing identity, authentication, and authorization.
5. Applying CQRS and Clean Architecture.
6. Developing reusable .NET libraries and NuGet packages.
7. Integrating messaging systems and distributed caching.
8. Automating CI/CD pipelines using Azure DevOps.
9. Deploying and configuring applications in Microsoft Azure.
10. Understanding production-oriented software engineering practices.

---

## 📌 Project Status

**Status:** In Progress

This repository represents an ongoing practical learning and implementation project.

The goal is not only to follow the course material but also to understand the underlying technologies, architectural decisions, implementation details, and engineering practices involved in developing modern .NET microservices.

As development progresses, I will update this repository with source code, implementation notes, architecture documentation, pipeline configurations, and deployment exercises.

---

## 👨‍💻 About

I am a Full-Stack Software Developer focused on TypeScript, React, C#/.NET, and Microsoft Azure.

This project forms part of my continuous development in enterprise backend engineering, distributed systems, microservices architecture, and cloud technologies.

**Building practical solutions. Understanding architecture. Engineering for scale.**
