using MediatR;

namespace EmployeeDepartment.Application.Features.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(int Id) : IRequest<Unit>;
