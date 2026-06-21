using EmployeeDepartment.Application.DTOs;
using EmployeeDepartment.Application.Interfaces;
using MediatR;

namespace EmployeeDepartment.Application.Features.Departments.Queries.GetAllDepartments;

public sealed class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IReadOnlyList<DepartmentDto>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IReadOnlyList<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _departmentRepository.GetAllAsync(cancellationToken);

        return departments.Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name,
            Employees = d.Employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                DepartmentId = e.DepartmentId,
                DepartmentName = d.Name
            }).ToList()
        }).ToList();
    }
}
