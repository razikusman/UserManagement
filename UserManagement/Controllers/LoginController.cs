using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.Model.Request;
using UserManagement.Services.Interfaces;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var res = await _loginService.Login(loginRequest);
            return Ok(res);
        }

        [HttpPut("id")]
        public async Task<JsonResult> ChangePasswordAsync(string id, string oldPas, string newPas)
        {
            var res = await _loginService.ChangePasswordAsync(id, oldPas, newPas);
            return Json(res);
        }
    }
}
