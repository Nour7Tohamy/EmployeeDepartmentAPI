using MediatR;

namespace Application.CQRS.Features.Employees.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(int Id) : IRequest<Unit>;
