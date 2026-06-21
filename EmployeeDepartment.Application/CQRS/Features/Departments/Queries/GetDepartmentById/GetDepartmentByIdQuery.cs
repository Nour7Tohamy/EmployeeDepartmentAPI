using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace Application.CQRS.Features.Departments.Queries.GetDepartmentById;

public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentDto>;
