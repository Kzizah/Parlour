using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using registrationform.Data;
using registrationform.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBContextConnection") ?? throw new InvalidOperationException("Connection string 'DBContextConnection' not found.");

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DBContext>();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opts  => opts.TokenLifespan=TimeSpan.FromHours(10));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "users" };
    foreach (var role in roles)
    {
        if (!await RoleManager.RoleExistsAsync(role))
            await RoleManager.CreateAsync(new IdentityRole(role));
    }
}

app.Run();
