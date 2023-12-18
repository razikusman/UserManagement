using Microsoft.AspNetCore.Mvc;
using UserManagement.Model.Response;
using UserManagement.Models.Model.Request;
using UserManagement.Services.Interfaces;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEpmloyeeService _epmloyeeService;

        public EmployeesController(IEpmloyeeService epmloyeeService)
        {
            _epmloyeeService = epmloyeeService;
        }

        [HttpPost]
        public async Task<JsonResult> CreateEmployeeAAsync(EmployeeRequest employeeRequest)
        {
            var res = await _epmloyeeService.CreateEmployeeAsync(employeeRequest);
            return Json(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _epmloyeeService.GetALlEmployeeAsync();
            return Json(res);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var res = await _epmloyeeService.GetEmployeeAsync(id);
            return Json(res);
        }
    }
}
