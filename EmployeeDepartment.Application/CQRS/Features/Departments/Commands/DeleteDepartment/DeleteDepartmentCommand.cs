using MediatR;

namespace Application.CQRS.Features.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(int Id) : IRequest<Unit>;
