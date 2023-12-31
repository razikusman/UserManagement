﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UserManagement.Models.Model;
using UserManagement.Model.Response;
using UserManagement.Services.Interfaces;
using UserManagement.Models.Model.Request;
using UserManagement.Model;
using System.Text;
using System.Collections.Specialized;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace UserManagement.Services
{
    public class EpmloyeeService : IEpmloyeeService
    {
        private readonly UserDBContext _context;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _memoryCache;

        public EpmloyeeService(UserDBContext userDBContext,
                               IEmailService emailService,
                               IMemoryCache memoryCache) 
        {
            _context = userDBContext;
            _emailService = emailService;
            _memoryCache = memoryCache;
        }
        public async Task<APIResponseModel<Employees>> CreateEmployeeAsync(EmployeeRequest employeeRequest)
        {
            try
            {
                var savedemp = new Employees();

                if (employeeRequest.EmpId == "-1")
                {
                    var all = await _context.employees.ToListAsync();
                    var lastEmpId = "";
                    if (all.Count > 1)
                    {
                        lastEmpId = all.Last().EmpId;
                    }
                    else
                    {
                        lastEmpId = all.FirstOrDefault().EmpId;
                    }
                    var empID = "";

                    int.TryParse(lastEmpId.Substring(3), out int lastId);
                    empID = "EMP" + (lastId + 1).ToString("D3");


                    string randompassword = CreatePassword();
                    var employee = new Employees()
                    {
                        Address = employeeRequest.Address,
                        Email = employeeRequest.Email,
                        EmpId = empID,
                        Fullname = employeeRequest.Fullname,
                        Joindate = employeeRequest.Joindate,
                        Password = employeeRequest.Password,
                        Phonenumber = employeeRequest.Phonenumber,
                        Salary = employeeRequest.Salary,
                        Status = employeeRequest.Status,
                        Username = employeeRequest.Username,
                        TempPassword = randompassword,

                        // add the salries to the saved employee
                        Salaries = CreateSalaries(employeeRequest.Salaries, empID)
                    };

                    //create data
                    _context.employees.Add(employee);


                    //saved employee
                    savedemp = await _context.employees.FirstOrDefaultAsync(x => x.EmpId == empID);

                    // send an email with temp pass word
                    await _emailService.SendEmailAsync(savedemp.EmpId, randompassword, savedemp.Email);

                }

                else
                {
                    savedemp = await _context.employees.FirstOrDefaultAsync(e => e.EmpId == employeeRequest.EmpId);

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeRequest, Employees>());
                    var mapper = config.CreateMapper();

                    mapper.Map(employeeRequest, savedemp);

                    _context.Entry(savedemp).State = EntityState.Modified;

                    _memoryCache.Set("logedinEmployee", savedemp);
                }

                //create entry in db
                await _context.SaveChangesAsync();

                //create response
                var response = new APIResponseModel<Employees>() 
                { 
                    Data = savedemp,
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

        private string CreatePassword()
        {
            Random random = new Random();
            
            const string letters = "MYRANDOMPASFENCE";

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 4; i++) 
            { 
                var letter = letters[random.Next(letters.Length)]; // lettervalue for temp passwrd
                var numb = random.Next(100); // Number value for temp passwrd

                //Append Both number nad letter to create temp password
                stringBuilder.Append(letter);
                stringBuilder.Append(numb);
            }

            return stringBuilder.ToString();
        }

        private List<Salaries> CreateSalaries(List<SalariesRequest> salaries, string empId)
        {
            var SalariesList = new List<Salaries>();
            var salary = new Salaries();

            foreach (var item in salaries)
            {
                salary.SalaryAmount = item.Salary;
                salary.Month = item.Month;
                salary.EmpId = empId;

                // add each salry to List
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
                var reslist = await _context.employees // get from employee table
                                            .Include(e => e.Salaries) // get the salaries from salry table
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
                //get the matching employee
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
