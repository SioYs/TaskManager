using Microsoft.EntityFrameworkCore;
using TaskManager.Data;


namespace TaskManagerWeb
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Identity;
    
    
    using Services;
    using TaskManager.Data.Models;
    using TaskManagerWeb.Verifications;

    public class Program
    {
        public static void Main(string[] args)
        {
            Nav.isShowed = false;
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDbContext<ManagerContext>(options => 
            //options.UseSqlServer(Configuration.ConnectionString));

            builder.Services.AddDbContext<ManagerContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            

            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskListService, TaskListService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVerificationService, VerificationService>();


            //FOR FUTURE PROJECTS
    //        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    //.AddCookie(options =>
    //{
    //    options.LoginPath = "/Account/Login";
    //    options.LogoutPath = "/Account/Logout";
    //});
    //        builder.Services.AddIdentity<Users, IdentityRole>()
    //    .AddEntityFrameworkStores<ManagerContext>()
    //    .AddDefaultTokenProviders();


            // Other services
            // ...


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}