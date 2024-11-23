using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var builderRazor = builder.Services.AddRazorPages();

builder.Services.AddDbContext<C500Hemis.Models.HemisContext>(options =>
    options.UseSqlServer("Server=tcp:c500.database.windows.net,1433;Database=dbHemisC500;User Id=c500;Password=@Abc1234"));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    builderRazor.AddRazorRuntimeCompilation();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
