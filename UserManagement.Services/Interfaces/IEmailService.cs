using UserManagement.Models.Model.Request;
using UserManagement.Models.Model;
using UserManagement.Model.Response;

namespace UserManagement.Services.Interfaces
{
    public interface IEmailService
    {
        Task<Boolean> SendEmailAsync(string id, string oldPas, string Email);
    }
}
