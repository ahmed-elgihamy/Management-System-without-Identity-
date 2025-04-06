using Management_System1.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Management_System1.Data
{
    public class ApplicationDBContext : DbContext
    {           
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
         optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Management_SystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=true");

       public ApplicationDBContext(DbContextOptions Options)
        {
            
        }

        public ApplicationDBContext()
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<CourseResult> CrsResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Role>().HasData(
                [

                new Role (){Id=1 ,Name="Admain"},
                new Role (){Id=2 ,Name="Student"},
                new Role (){Id=3 ,Name="Instructor"}
                ]);


        }

    }
}
