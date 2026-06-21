using EmployeeDepartment.Application.DTOs;
using MediatR;

namespace EmployeeDepartment.Application.Features.Departments.Queries.GetDepartmentById;

public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentDto>;
