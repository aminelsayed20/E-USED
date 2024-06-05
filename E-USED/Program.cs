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
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;
using NuGet.Protocol.Core.Types;
using E_USED.Repository;
using E_USED.Models.Entity.Product;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Diagnostics;

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

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages services

// Transients
builder.Services.AddTransient<IEmailSender, MyEmailSender>();
builder.Services.AddTransient<IRepository<Product>, Repository<Product>>();
//---------------//

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:Client"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        // that after i put my secret codes in "User-Secter" using this command
        //cd C:\Users\Amin-Elsayed\source\repos\E-USED\E-USED
        //dotnet user-secrets set "Authentication:Google:Client" "*secret*jgpum.apps.googleusercontent.com"
        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "sub");
        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
        options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
        options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
        // this for maping the name-email-image form google account
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


//  auto update database and seeding data   &   create logger
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await ContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    Debug.WriteLine(ex);

    logger.LogError(ex, "Error Migration");
}


app.Run();
