using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace Application.CQRS.Features.Departments.Queries.GetAllDepartments;

public record GetAllDepartmentsQuery : IRequest<IReadOnlyList<DepartmentDto>>;
