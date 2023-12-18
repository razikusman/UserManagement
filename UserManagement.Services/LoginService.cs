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

        public async Task<Employees> ChangePasswordAsync(string id, string oldPas, string newPas)
        {
            try
            {
                var emp = await _context.employees.FirstOrDefaultAsync(e => e.TempPassword == oldPas && e.EmpId == id);

                if (emp != null)
                {
                    emp.Password = newPas;
                    _context.employees.Entry(emp).State = EntityState.Modified;
                    var res = await _context.SaveChangesAsync();

                    if (res > 0)
                    {
                        return emp;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else { throw new Exception(); }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
