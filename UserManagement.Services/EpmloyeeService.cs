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
    public class EpmloyeeService : IEpmloyeeService
    {
        private readonly UserDBContext _context;

        public EpmloyeeService(UserDBContext userDBContext) 
        {
            _context = userDBContext;
        }
        public async Task<APIResponseModel<EmployeeRequest>> CreateEmployeeAsync(EmployeeRequest employeeRequest)
        {
            try
            {
                var employee = new Employees()
                {
                    Address = employeeRequest.Address,
                    Email = employeeRequest.Email,
                    EmpId = employeeRequest.EmpId,
                    Fullname = employeeRequest.Fullname,
                    Joindate = employeeRequest.Joindate,
                    Password = employeeRequest.Password,
                    Phonenumber = employeeRequest.Phonenumber,
                    Salary = employeeRequest.Salary,
                    Status = employeeRequest.Status,
                    Username = employeeRequest.Username,
                    TempPassword = employeeRequest.TempPassword,
                    Salaries = CreateSalaries(employeeRequest.Salaries)
            };


                // create an entry in employees table
                //var result = await _context.SaveChangesAsync();

                //saved employee
                var savedemp = await _context.employees.FirstOrDefaultAsync(x => x.EmpId == employeeRequest.EmpId);

                // add the salries to the saved employee
                //savedemp.Salaries = CreateSalaries( employeeRequest.Salaries, savedemp.EmpId);
                //_context.employees.Entry(savedemp).State = EntityState.Modified;
                _context.employees.Add(employee);

                await _context.SaveChangesAsync();

                //create response
                var response = new APIResponseModel<EmployeeRequest>() 
                { 
                    Data = employeeRequest,
                    IsError = false,
                    ResponseCode = (int)HttpStatusCode.OK,
                };

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<Salaries> CreateSalaries(List<SalariesRequest> salaries)
        {
            var SalariesList = new List<Salaries>();
            var salary = new Salaries();
            foreach (var item in salaries)
            {
                salary.SalaryAmount = item.Salary;
                salary.Month = item.Month;
                SalariesList.Add(salary);
            }

            return SalariesList;
        }

        public Task<EmployeeRequest> DeleteEmployeeAsync(string EmployeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Employees>> GetALlEmployeeAsync()
        {
            try
            {
                var reslist = await _context.employees
                                            .Include(e => e.Salaries)
                                            .ToListAsync();
                return reslist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employees> GetEmployeeAsync(string EmployeeId)
        {
            try
            {
                var res = await _context.employees.FirstOrDefaultAsync(list => list.EmpId == EmployeeId);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<EmployeeRequest> UpdateEmployeeAsync(EmployeeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
