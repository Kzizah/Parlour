using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using registrationform.Migrations;
using registrationform.Models.Filters;
using registrationform.Models.Repository;

namespace registrationform
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {

            configuration = configuration;
        }

        public IConfiguration Configuration { get;  }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<AuditRepository, AuditRepository>();
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(AuditFilterAttribute));
            });

            services.AddScoped<IAuditRepository>();

            services.AddScoped<AuditFilterAttribute>();
            services.AddSession(options =>
            {

                options.Cookie.Name = ".Audit.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite=SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Portal}/{action=login}/{id?)");

            });


        }
    }
}
