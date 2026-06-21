using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace EmployeeDepartment.Application.Features.Employees.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
