// using Microsoft.EntityFrameworkCore;
// using RuralBankWeb.Data;
// using RuralBankWeb.Services;

// var builder = WebApplication.CreateBuilder(args);

// // Add Razor Pages services
// builder.Services.AddRazorPages();

// // Register the database context
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// // Register application services
// builder.Services.AddScoped<IJobOpeningService, JobOpeningService>();
// builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();
// app.UseAuthorization();

// app.MapRazorPages();

// app.Run();


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RuralBankWeb.Data;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddScoped<IJobOpeningService, JobOpeningService>();
builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddScoped<IPageContentService, PageContentService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // MUST come before UseAuthorization
app.UseAuthorization();

app.MapRazorPages();

// Seed admin role + default admin account on startup
using (var scope = app.Services.CreateScope())
{
    await SeedData.InitializeAsync(scope.ServiceProvider);
}

app.Run();