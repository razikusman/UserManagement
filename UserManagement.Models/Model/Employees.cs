using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using UserManagement.Models.Model.Request;

namespace UserManagement.Models.Model
{
    public class Employees
    {
        public int EmployeesId { get; set; }
        public string? EmpId { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Salary { get; set; }
        public string? Joindate { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; } //-  active/inactive
        public string? TempPassword { get; set; }
        public List<Salaries> Salaries { get; set; }

    }
}
