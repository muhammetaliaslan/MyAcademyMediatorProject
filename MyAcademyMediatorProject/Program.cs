using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Context;
using MyAcademyMediatorProject.Patterns.Observer;
using MyAcademyMediatorProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// DATABASE
// ----------------------
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ----------------------
// GENERIC REPOSITORY
// ----------------------
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// ----------------------
// MEDIATR
// ----------------------
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

// ----------------------
// OBSERVER SERVICES
// ----------------------
builder.Services.AddScoped<IOrderObserver, OrderCreatedLogObserver>();
builder.Services.AddScoped<OrderSubject>();

builder.Services.AddScoped<ContactSubject>();
builder.Services.AddScoped<IContactObserver, ContactLogObserver>();

// ----------------------
// MVC
// ----------------------
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ----------------------
// ERROR HANDLING
// ----------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ----------------------
// MIDDLEWARE
// ----------------------
app.UseHttpsRedirection();
app.UseStaticFiles();   // CSS, JS, Images için ÇOK ÖNEMLÝ

app.UseRouting();

app.UseAuthorization();

// ----------------------
// ROUTES
// ----------------------
app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
