using Management_System1.Controllers;
using Management_System1.Data;
using Management_System1.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Management_System1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            

                options.UseSqlServer(builder.Configuration.GetConnectionString("CON1")) 
            );
              builder.Services.AddScoped<IStudentRepository, StudentRepository>();
              builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
              builder.Services.AddScoped<ICourseRepository, CourseRepository>();
              builder.Services.AddScoped<ICourseResultRepository, CourseResultRepository>();
              builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
              builder.Services.AddScoped<IUserRepository, UserRepository>();
              builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(s =>
            {

            });

          /*  builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
             builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();*/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();//get user data from request from cookies princible
            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
