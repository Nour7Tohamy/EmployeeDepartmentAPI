#!/bin/bash
echo "=== EmployeeDepartmentAPI Setup Script ==="

# Restore packages
echo "Restoring NuGet packages..."
dotnet restore EmployeeDepartmentAPI.sln

# Build solution
echo "Building solution..."
dotnet build EmployeeDepartmentAPI.sln -c Release

# Add EF migration (run from Infrastructure project context)
echo "Adding EF Core migration..."
dotnet ef migrations add InitialCreate \
  --project EmployeeDepartment.Infrastructure/EmployeeDepartment.Infrastructure.csproj \
  --startup-project EmployeeDepartment.API/EmployeeDepartment.API.csproj \
  --output-dir Data/Migrations

# Apply migration
echo "Applying migrations..."
dotnet ef database update \
  --project EmployeeDepartment.Infrastructure/EmployeeDepartment.Infrastructure.csproj \
  --startup-project EmployeeDepartment.API/EmployeeDepartment.API.csproj

# Run the API
echo "Starting API..."
dotnet run --project EmployeeDepartment.API/EmployeeDepartment.API.csproj
