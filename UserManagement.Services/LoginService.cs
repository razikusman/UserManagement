using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UserManagement.Models.Model;
using UserManagement.Model.Response;
using UserManagement.Services.Interfaces;
using UserManagement.Models.Model.Request;
using UserManagement.Model;

namespace UserManagement.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserDBContext _context;

        public LoginService(UserDBContext userDBContext) 
        {
            _context = userDBContext;
        }
        public async Task<Boolean> Login(LoginRequest loginRequest)
        {
            try
            {
                //check user Exist
                var savedemp = await _context.employees.FirstOrDefaultAsync(x => x.Username == loginRequest.UserName && x.Password == loginRequest.Password);

                if (savedemp != null && Boolean.Parse(savedemp.Status))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
