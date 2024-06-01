using E_USED.Areas.Identity.Pages.Account;
using E_USED.Data;
using E_USED.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SellingUsedThings.Models.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services
    .AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI() // Ensure the default UI is added
    .AddDefaultTokenProviders(); // Ensure default token providers are added


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages services

// Transients
builder.Services.AddTransient<IEmailSender, MyEmailSender>();
//---------------//

builder.Services.AddAuthentication()
    .AddGoogle(option =>
    {
        option.ClientId = builder.Configuration["Authentication:Google:Client"]; 
        option.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        // that after i put my secret codes in "User-Secter" using this command
        //cd C:\Users\Amin-Elsayed\source\repos\E-USED\E-USED
        //dotnet user-secrets set "Authentication:Google:Client" "*secret*jgpum.apps.googleusercontent.com"
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Map Razor Pages

app.Run();
