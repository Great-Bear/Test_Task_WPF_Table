using Microsoft.EntityFrameworkCore;
using Test_Task_WPF_Table.Classes;

namespace MySQLApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=1234;database=usersdb5;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}