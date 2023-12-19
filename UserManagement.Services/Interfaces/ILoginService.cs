using UserManagement.Models.Model.Request;
using UserManagement.Models.Model;
using UserManagement.Model.Response;

namespace UserManagement.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Employees> ChangePasswordAsync(string id, string oldPas, string newPas);
        Task<Boolean> Login(LoginRequest loginRequest);
        Task<Boolean> LogOut(string id);
    }
}
