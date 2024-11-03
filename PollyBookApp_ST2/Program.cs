using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using PollyBookApp_ST2.Models;
using PollyBookApp_ST2.Models.Observer;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Models.Strategy;
using PollyBookApp_ST2.Repos;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Custom services
builder.Services.AddScoped<UsersRepo>();

builder.Services.AddSingleton<ReadingItemNotifier>();
builder.Services.AddTransient<INotificationObserver, ConsoleNotificationObserver>();


builder.Services.AddScoped<ISearchStrategy, TitleSearchStrategy>();
builder.Services.AddScoped<SearchContext>();

builder.Services.AddDbContext<BookAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


//Local settings
var supportedCultures = new[] { new CultureInfo("en-US") };
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
