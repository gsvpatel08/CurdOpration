using CurdOperation.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurdOperation.Data
{
    public class ApplicationDBContext : DbContext
    {
        

        public ApplicationDBContext(DbContextOptions  options) : base(options)
        {
        }

        
        public DbSet<Employee> Employees { get; set; }
    }
}


