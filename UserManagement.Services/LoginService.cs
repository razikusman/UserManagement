using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UserManagement.Models.Model;
using UserManagement.Model.Response;
using UserManagement.Services.Interfaces;
using UserManagement.Models.Model.Request;
using UserManagement.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace UserManagement.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserDBContext _context;
        private readonly IMemoryCache _memoryCache;

        public LoginService(UserDBContext userDBContext,IMemoryCache memoryCache) 
        {
            _context = userDBContext;
            _memoryCache = memoryCache;
        }
        public async Task<Boolean> Login(LoginRequest loginRequest)
        {
            try
            {
                //check user Exist
                var savedemp = await _context.employees.FirstOrDefaultAsync(x => x.Username == loginRequest.UserName && x.Password == loginRequest.Password);

                // if emp exist and status true/ active
                if (savedemp != null && Boolean.Parse(savedemp.Status))
                {
                    var token = await createToken(savedemp);
                    _memoryCache.Set(savedemp.EmpId, token);
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

        private async Task<String> createToken(Employees savedemp)
        {
            var employeestring = savedemp.EmpId + savedemp.Username + savedemp.Password;
            return employeestring;
        }

        public async Task<Employees> ChangePasswordAsync(string id, string oldPas, string newPas)
        {
            try
            {
                //get the matching employee with id and temp password
                var emp = await _context.employees.FirstOrDefaultAsync(e => e.TempPassword == oldPas && e.EmpId == id);

                // if emp is not null
                if (emp != null)
                {
                    //assign new pass
                    emp.Password = newPas;
                    _context.employees.Entry(emp).State = EntityState.Modified;
                    var res = await _context.SaveChangesAsync();

                    //if save is success
                    if (res > 0)
                    {
                        return emp;
                    }
                    // else failure response
                    else
                    {
                        throw new Exception();
                    }
                }
                // else throw unauth exception
                else { throw new Exception(); }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
