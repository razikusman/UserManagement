using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserManagement.Models.Model
{
    public class Salaries
    {
        public int SalariesId { get; set; }
        public string Month { get; set; }
        public string SalaryAmount { get; set; }
        public string EmpId { get;}

        [JsonIgnore]
        public Employees Employee { get; set; }
    }
}
