using UserManagement.Model;

namespace UserManagement.Models.Model.Request
{
    public class EmployeeRequest
    {
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


        public List<SalariesRequest>? Salaries { get; set; }
    }
}
