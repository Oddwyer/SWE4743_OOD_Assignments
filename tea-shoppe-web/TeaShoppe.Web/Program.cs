using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Application.Services;
using TeaShoppe.Web.Infrastructure.Repository;
using TeaShoppe.Web.Application.Factories;

// Create application builder which includes service collection (holds instructions).
var builder = WebApplication.CreateBuilder(args);

// Add MVC services and inform Razor where to find views.
builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Web/Views/{1}/{0}.cshtml");
    options.ViewLocationFormats.Add("/Web/Views/Shared/{0}.cshtml");
});

// Register application and infrastructure services with DI.
// InventoryRepository is registered as a singleton shared across the app.
builder.Services.AddScoped<IInventoryQueryService, InventoryQueryService>();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<PaymentStrategyFactory>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();

// Build the application and finalize the DI container (uses service
// collection instructions to build and supply objects at runtime).
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

// Redirect from HTTP to secure HTTPS.
app.UseHttpsRedirection();

// Configure middleware (routing and authorization) and endpoint routing (static asset -wwwroot files- mapping).
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

// Map default controller route.
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();