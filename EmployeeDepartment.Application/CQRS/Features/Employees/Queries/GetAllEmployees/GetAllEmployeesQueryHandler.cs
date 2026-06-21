using EmployeeDepartment.Application.DTOs;
using EmployeeDepartment.Application.Interfaces;
using MediatR;

namespace Application.CQRS.Features.Employees.Queries.GetAllEmployees;

public sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IReadOnlyList<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IReadOnlyList<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAllAsync(cancellationToken);

        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            Name = e.Name,
            DepartmentId = e.DepartmentId,
            DepartmentName = e.Department?.Name ?? string.Empty
        }).ToList();
    }
}
