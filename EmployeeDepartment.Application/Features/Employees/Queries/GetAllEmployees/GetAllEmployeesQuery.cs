using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace EmployeeDepartment.Application.Features.Employees.Queries.GetAllEmployees;

public record GetAllEmployeesQuery : IRequest<IReadOnlyList<EmployeeDto>>;
