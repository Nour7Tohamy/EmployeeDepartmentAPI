
using EmployeeDepartment.Domain.Entities;

namespace EmployeeDepartment.Application.Interfaces;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Department>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Department> AddAsync(Department department, CancellationToken cancellationToken = default);
    Task UpdateAsync(Department department, CancellationToken cancellationToken = default);
    Task DeleteAsync(Department department, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
}
