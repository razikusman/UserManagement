using Microsoft.EntityFrameworkCore;

namespace UserManagement.Models.Model
{
    public class UserDBContext : DbContext
    {
        public UserDBContext( DbContextOptions<UserDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Salaries> salaries { get; set; }
    }
}
