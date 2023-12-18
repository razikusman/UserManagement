using UserManagement.Models.Model.Request;
using UserManagement.Models.Model;
using UserManagement.Model.Response;

namespace UserManagement.Services.Interfaces
{
    public interface IEpmloyeeService
    {
        Task<APIResponseModel<Employees>> CreateEmployeeAsync(EmployeeRequest employeeRequest);
        Task<EmployeeRequest> UpdateEmployeeAsync(EmployeeRequest request);
        Task<EmployeeRequest> DeleteEmployeeAsync(string EmployeeId);
        Task<IList<Employees>> GetALlEmployeeAsync();
        Task<Employees> GetEmployeeAsync(string EmployeeId);
    }
}
