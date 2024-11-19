using Microsoft.EntityFrameworkCore;

namespace WebApplicationAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

       public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HASNAA-ABDELRAH;Database=EmployeeSysByAPI;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
