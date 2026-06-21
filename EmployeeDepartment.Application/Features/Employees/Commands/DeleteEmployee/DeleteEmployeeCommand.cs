using MediatR;

namespace EmployeeDepartment.Application.Features.Employees.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(int Id) : IRequest<Unit>;
