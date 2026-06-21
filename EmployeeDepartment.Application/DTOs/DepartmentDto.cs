namespace EmployeeDepartment.Application.DTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IReadOnlyList<EmployeeDto> Employees { get; set; } = [];
}
