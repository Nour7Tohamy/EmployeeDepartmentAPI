# EmployeeDepartmentAPI

A **production-ready** ASP.NET Core Web API built with **.NET 10**, following **Clean Architecture** and **CQRS** patterns.

## Architecture

```
EmployeeDepartmentAPI/
├── EmployeeDepartment.Domain/          # Entities only — no dependencies
│   └── Entities/
│       ├── Employee.cs
│       └── Department.cs
├── EmployeeDepartment.Application/     # CQRS, DTOs, Interfaces, Validators
│   ├── Common/
│   │   └── ValidationBehavior.cs
│   ├── DTOs/
│   │   ├── EmployeeDto.cs
│   │   └── DepartmentDto.cs
│   ├── Interfaces/
│   │   ├── IEmployeeRepository.cs
│   │   └── IDepartmentRepository.cs
│   ├── Features/
│   │   ├── Employees/
│   │   │   ├── Commands/
│   │   │   │   ├── CreateEmployee/
│   │   │   │   ├── UpdateEmployee/
│   │   │   │   └── DeleteEmployee/
│   │   │   └── Queries/
│   │   │       ├── GetEmployeeById/
│   │   │       └── GetAllEmployees/
│   │   └── Departments/
│   │       ├── Commands/
│   │       │   ├── CreateDepartment/
│   │       │   ├── UpdateDepartment/
│   │       │   └── DeleteDepartment/
│   │       └── Queries/
│   │           ├── GetDepartmentById/
│   │           └── GetAllDepartments/
│   └── DependencyInjection.cs
├── EmployeeDepartment.Infrastructure/  # EF Core, Repositories, SQL Server
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Configurations/
│   │   ├── EmployeeConfiguration.cs
│   │   └── DepartmentConfiguration.cs
│   ├── Repositories/
│   │   ├── EmployeeRepository.cs
│   │   └── DepartmentRepository.cs
│   └── DependencyInjection.cs
└── EmployeeDepartment.API/             # Controllers, Middleware, Program.cs
    ├── Controllers/
    │   ├── EmployeesController.cs
    │   └── DepartmentsController.cs
    ├── Middleware/
    │   └── ExceptionHandlingMiddleware.cs
    └── Program.cs
```

## Technologies

| Technology | Version | Purpose |
|---|---|---|
| .NET | 10.0 | Runtime |
| ASP.NET Core | 10.0 | Web API Framework |
| Entity Framework Core | 10.0 | ORM |
| SQL Server | - | Database |
| MediatR | 12.4.1 | CQRS / Mediator Pattern |
| FluentValidation | 11.11 | Input Validation |
| Swashbuckle | 7.3.1 | Swagger / OpenAPI |

## Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server (local or Docker)

### 1. Configure Connection String

Edit `EmployeeDepartment.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDepartmentDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 2. Run Database Migrations

```bash
cd EmployeeDepartment.API
dotnet ef migrations add InitialCreate --project ../EmployeeDepartment.Infrastructure
dotnet ef database update
```

### 3. Run the API

```bash
dotnet run --project EmployeeDepartment.API
```

Visit Swagger UI at: **http://localhost:5000**

## API Endpoints

### Departments

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/departments` | Get all departments |
| GET | `/api/departments/{id}` | Get department by ID |
| POST | `/api/departments` | Create department |
| PUT | `/api/departments/{id}` | Update department |
| DELETE | `/api/departments/{id}` | Delete department |

### Employees

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/employees` | Get all employees |
| GET | `/api/employees/{id}` | Get employee by ID |
| POST | `/api/employees` | Create employee |
| PUT | `/api/employees/{id}` | Update employee |
| DELETE | `/api/employees/{id}` | Delete employee |

## Sample Requests

### Create Department
```http
POST /api/departments
Content-Type: application/json

{
  "name": "Engineering"
}
```

### Create Employee
```http
POST /api/employees
Content-Type: application/json

{
  "name": "Ahmed Mohamed",
  "departmentId": 1
}
```
