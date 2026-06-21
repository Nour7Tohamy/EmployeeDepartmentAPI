using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace EmployeeDepartment.Application.Features.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand(string Name, int DepartmentId) : IRequest<EmployeeDto>;
