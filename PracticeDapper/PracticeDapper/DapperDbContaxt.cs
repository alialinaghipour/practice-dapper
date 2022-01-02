using Microsoft.EntityFrameworkCore;
using PracticeDapper.Models;

namespace PracticeDapper
{
    public class DapperDbContaxt:DbContext
    {
        public DapperDbContaxt(DbContextOptions<DapperDbContaxt> options):base(options)
        {

        }

        public DbSet<Company> Companies{ get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
