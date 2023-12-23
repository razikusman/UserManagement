﻿using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.Model;
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
        public async Task<JsonResult> LoginAsync(LoginRequest loginRequest)
        {
            var res = await _loginService.Login(loginRequest);
            return Json(res);
        }

        [HttpPost("isAdmin")]
        public async Task<JsonResult> AdminLoginAsync(LoginRequest loginRequest, bool isAdmin)
        {
            var res = await _loginService.Login(loginRequest);
            return Json(res);
        }

        [HttpPost("id")]
        public async Task<JsonResult> LogOutAsync(string id)
        {
            var res = await _loginService.LogOut(id);
            return Json(res);
        }

        [HttpPut("username")]
        public async Task<JsonResult> ChangePasswordAsync(string username, string oldPas, string newPas)
        {
            var res = await _loginService.ChangePasswordAsync(username, oldPas, newPas);
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> GetSession()
        {
            var res = await _loginService.GetSession();
            return Json(res);
        }
    }
}
