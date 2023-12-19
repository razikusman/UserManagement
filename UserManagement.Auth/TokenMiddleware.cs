using Microsoft.Extensions.Caching.Memory;
using UserManagement.Models.Model;
using UserManagement.Services.Interfaces;

namespace UserManagement.Auth
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public TokenMiddleware(RequestDelegate next, AppSettings appSettings)
        {
            _next = next;
            _appSettings = appSettings;
        }

        public async Task Invoke(HttpContext context,
                                 IEpmloyeeService epmloyeeService,
                                 IMemoryCache memoryCache)
        {
            //var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = context.Request.Cookies["token"];
            var employeeCode = getEmployeeCode(token);
            if (!string.IsNullOrEmpty(employeeCode))
            {
                Employees? employee = null;
                
                // Store user in Memory Cache
                if (String.IsNullOrWhiteSpace(memoryCache.Get(employeeCode) as string))
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    var user = await epmloyeeService.GetEmployeeAsync(employeeCode);
                    context.Items[nameof(Employees)] = user;
                }

            }

            await _next(context);
        }

        private string getEmployeeCode(string token)
        {
            return !String.IsNullOrWhiteSpace(token) ? token.Substring(0, 3) : null;
        }
    }
}
