# Randevium API

**Randevium API** is a backend service built using modern technologies, providing robust and scalable solutions for user authentication, appointment management, and other core functionalities of the Randevium platform.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Controllers and Features](#controllers-and-features)
- [Entities and Domain Models](#entities-and-domain-models)
- [Cross-Cutting Concerns](#cross-cutting-concerns)
- [Code-First Approach](#code-first-approach)
- [Installation & Setup](#installation--setup)
- [Environment Variables](#environment-variables)
- [Running the Server](#running-the-server)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Overview

The Randevium API serves as the backend for the Randevium platform. It leverages **.NET 8**, following clean architecture principles to ensure maintainability and scalability.

## Features

- **User Authentication**: Secure signup, login, and token-based authentication (JWT).
- **Appointment Management**: Endpoints to create, read, update, and delete appointments.
- **Employee and Company Management**: APIs for managing employees, companies, and services.
- **Cross-Cutting Concerns**: Centralized logging, exception handling, and request/response pipelines.
- **Code-First Approach**: Leverages Entity Framework Core to define the database schema through models.
- **Database Integration**: Persistent storage with PostgreSQL and Entity Framework Core.
- **Containerization**: Docker and Docker Compose for seamless deployment.
- **API Documentation**: Auto-generated Swagger/OpenAPI documentation.
- **CQRS Pattern**: Command and Query Responsibility Segregation for efficient handling of operations and queries.

## Tech Stack

- **Language**: C#
- **Framework**: .NET 8
- **Database**: PostgreSQL with Entity Framework Core
- **Containerization**: Docker and Docker Compose
- **Authentication**: JSON Web Tokens (JWT)
- **API Documentation**: Swagger (OpenAPI Specification)
- **Logging**: Serilog

## Project Structure

The project adheres to Clean Architecture principles, ensuring clear separation of concerns:

```plaintext
randevium-api/
├── Application/            # Application layer (use cases, service interfaces)
├── Domain/                 # Core domain models and logic
├── Infrastructure/         # External services and technical implementations
├── Persistence/            # Database context and repository implementations
├── WebAPI/                 # API controllers and endpoint definitions
│   ├── Controllers/        # HTTP request handlers
│   └── Program.cs          # Application startup configuration
├── corePackages/           # Cross-cutting concerns and reusable packages
│   ├── Core.Application/   # Application-specific pipelines and logic
│   ├── Core.CrossCuttingConcerns/
│   │   ├── Logging/        # Logging configurations using Serilog
│   │   └── Exceptions/     # Centralized exception handling
│   ├── Core.Persistence/   # Persistence-related features
│   └── Core.Security/      # Security-related utilities
├── Dockerfile              # Docker configuration
├── docker-compose.yml      # Docker Compose configuration
└── randevium-api.sln       # .NET solution file
```
## Controllers and Features

The **Controllers** in the `WebAPI` layer define the API endpoints and encapsulate features:

- **AuthController.cs**: Handles user authentication, including login and registration.
- **AppointmentController.cs**: Manages appointments, including creating, updating, and deleting.
- **AppointmentDetailController.cs**: Provides detailed information about appointments.
- **CompanyController.cs**: Manages companies, their details, and operations.
- **EmployeeController.cs**: Handles employees, their profiles, and schedules.
- **ServiceController.cs**: Manages services offered by companies.

These controllers implement the CQRS pattern, ensuring separation between read (queries) and write (commands) operations for better scalability and maintainability.

## Entities and Domain Models

The **Entities** in the `Domain` layer represent the core business logic:

- **Appointment.cs**: Defines the primary appointment model.
- **AppointmentDetail.cs**: Extends details for an appointment (e.g., notes, metadata).
- **AppointmentTimeSlot.cs**: Represents specific time slots for appointments.
- **AppUser.cs**: Represents system users, including customers and employees.
- **Company.cs**: Defines a company and its attributes.
- **Employee.cs**: Represents an employee of a company, including roles and availability.
- **Service.cs**: Represents services provided by a company, linked to appointments.

These domain models ensure a clear separation of concerns, enabling business logic to remain independent of infrastructure and APIs.

## Cross-Cutting Concerns

The API centralizes common functionalities using reusable components under `corePackages`:

- **Logging**: Located in `src/corePackages/Core.CrossCuttingConcerns/Logging`, the API uses Serilog for structured and detailed logging. Logs capture request metadata, exceptions, and application events.
- **Exception Handling**: Centralized in `src/corePackages/Core.CrossCuttingConcerns/Exceptions`, ensuring consistent and user-friendly error responses across the API.
- **Pipelines**: Found in `src/corePackages/Core.Application/Pipelines`, they enable request/response interception and manipulation for validation, authorization, and performance monitoring.
- **Security**: Utilities and configurations under `src/corePackages/Core.Security/Core.Security.csproj` provide JWT validation, user authentication, and role-based access control.
- **Persistence**: Reusable persistence features under `src/corePackages/Core.Persistence/Core.Persistence.csproj` include repository patterns and database utilities.

## Code-First Approach

The API follows a **Code-First** approach with Entity Framework Core:

1. **Entity Definitions**: Models (e.g., `Appointment`, `User`) define the database schema.
2. **Migrations**: Changes to models generate migrations, which are applied to the database.
3. **DbContext**: The `DbContext` class manages database interactions and enforces schema relationships.
