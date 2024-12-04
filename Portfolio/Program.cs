using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();

// Add session services
builder.Services.AddSession(options =>
{
    // options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;                // Ensure cookie is HTTP-only
    options.Cookie.IsEssential = true;             // Mark session cookie as essential
});

// Register application services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security for production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware
app.UseSession();

app.UseAuthorization();

// Map area-specific routes
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Client}/{controller=Home}/{action=Index}/{id?}");



app.Run();
