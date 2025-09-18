using Microsoft.EntityFrameworkCore;  // Thư viện EF Core
using DemoMVC.Models;               // Chứa class Person (entity/model)

namespace DemoMVC.Data
{
    // DbContext đại diện cho Database
    public class ApplicationDbContext : DbContext
    {
        // Constructor nhận DbContextOptions để cấu hình (connection string, provider...)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSet<Person> ánh xạ tới bảng Person trong database
        public DbSet<Person> Person { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
