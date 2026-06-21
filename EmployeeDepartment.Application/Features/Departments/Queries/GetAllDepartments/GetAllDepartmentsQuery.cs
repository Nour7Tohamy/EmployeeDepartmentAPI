using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace EmployeeDepartment.Application.Features.Departments.Queries.GetAllDepartments;

public record GetAllDepartmentsQuery : IRequest<IReadOnlyList<DepartmentDto>>;
