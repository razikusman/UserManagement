using UserManagement.Models.Model.Request;
using UserManagement.Models.Model;
using UserManagement.Model.Response;

namespace UserManagement.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Boolean> Login(LoginRequest loginRequest);
    }
}
