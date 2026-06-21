using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace Application.CQRS.Features.Employees.Queries.GetAllEmployees;

public record GetAllEmployeesQuery : IRequest<IReadOnlyList<EmployeeDto>>;
