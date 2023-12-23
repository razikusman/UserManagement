using UserManagement.Models.Model.Request;
using UserManagement.Models.Model;
using UserManagement.Model.Response;

namespace UserManagement.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Employees> ChangePasswordAsync(string username, string oldPas, string newPas);
        Task<string> Login(LoginRequest loginRequest);
        Task<Boolean> LogOut(string id);
        Task<APIResponseModel<Employees>> GetSession();
    }
}
