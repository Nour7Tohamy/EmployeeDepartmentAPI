using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace Application.CQRS.Features.Employees.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
