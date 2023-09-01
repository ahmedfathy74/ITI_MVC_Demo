using ITI_MVC_Demo.Models;
using ITI_MVC_Demo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // add service to be used and knon when the app is statred to know

            builder.Services.AddDbContext<ITIEntity>(options => 
            options.UseSqlServer("Data Source=.; Initial Catalog=ITIMVCDB ;Integrated Security=True;"));
            // add usermanger - siginmanager - rolemanager
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ITIEntity>();

            //register my custom service "your class "
            //services.AddSingleton<typesource,Type create instance>
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddSession(config =>
            {
                config.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            #region Custom Middleware "Inline Component"
            /*
            app.Use( async (HttpContext,next) =>
            {
                // Write response
                await HttpContext.Response.WriteAsync("1)Middle Ware 1\n");
                // Call Next
                await next.Invoke();

            }); //Execute , call next MiddleWare

            app.Use(async (HttpContext, next) =>
            {
                // Write response
                await HttpContext.Response.WriteAsync("2)Middle Ware 2\n");
                // Call Next
                await next.Invoke();

            }); //Execute , call next MiddleWare

            // Terminate 
            app.Run(async (HttpContext) =>
            {
                await HttpContext.Response.WriteAsync("3)Terminate\n");
            });
            */
            #endregion

            // Built in Middleware (Component)

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); // html , CSS , JS files wwwroot

            app.UseRouting();// bt3ml route aw mapping ly controller and for action using mappcontrollerroute

            app.UseAuthentication(); // check for cokkie is vaild or not (that has username & Password)

            app.UseAuthorization(); // hinte for using authentection before authorization

            app.UseSession(); // add configure for session to be used in the project 

            app.MapControllerRoute( // mapping for the specific URL
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // using to run application and not shut down the app.
            app.Run();
        }
    }
}