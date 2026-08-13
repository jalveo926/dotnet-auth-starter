# .NET Authentication Starter

Reusable authentication backend built with ASP.NET Core and Entity Framework Core.

This project provides a foundation for implementing authentication in future applications, including user registration, password hashing, validation, login, and JWT-based authentication.

The goal is to develop the authentication system independently so it can later be reused as a starting point for other .NET projects.

## Features

- User registration
- Input validation
- Password hashing
- Duplicate username and email validation
- Standardized error codes
- Entity Framework Core migrations
- MySQL database integration
- Login authentication
- JWT-based authentication
- Protected API endpoints

## Technologies

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- MySQL
- Pomelo.EntityFrameworkCore.MySql
- JWT
- Swagger / OpenAPI

## Project Structure

```text
├── Controllers/
├── Data/
│   ├── Entities/
│   └── Configurations/
├── DTOs/
│   └── Auth/
├── Services/
│   └── Results/
├── Common/
│   ├── Errors/
│   └── Utilities/
├── Migrations/
├── Program.cs
└── appsettings.json