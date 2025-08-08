using PayrollSystem.src.microservices.Employee.DTOs;
using PayrollSystem.src.microservices.shared.Common;

namespace PayrollSystem.src.microservices.Employee.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(long id);
        Task<bool> CreateAsync(EmployeeDto dto);
        Task<bool> UpdateAsync(long id, EmployeeDto dto);
        Task<bool> DeleteAsync(long id);
        Task<ApiResult<EmployeeDto>> CreateEmployeeAsync(EmployeeDto dto);
    }
}
