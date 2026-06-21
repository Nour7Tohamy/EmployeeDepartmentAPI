using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace Application.CQRS.Features.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand(string Name, int DepartmentId) : IRequest<EmployeeDto>;
