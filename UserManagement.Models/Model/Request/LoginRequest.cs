using UserManagement.Model;

namespace UserManagement.Models.Model.Request
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
