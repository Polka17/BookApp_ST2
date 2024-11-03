using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using PollyBookApp_ST2.Models;
using PollyBookApp_ST2.Models.Observer;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Models.Strategy;
using PollyBookApp_ST2.Repos;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UsersRepo>();

builder.Services.AddSingleton<ReadingItemNotifier>();

// Register the observer as a transient or singleton depending on your needs
builder.Services.AddTransient<INotificationObserver, ConsoleNotificationObserver>();

// Register the search strategies
builder.Services.AddScoped<ISearchStrategy, TitleSearchStrategy>();
// Register the SearchContext
builder.Services.AddScoped<SearchContext>();

builder.Services.AddDbContext<BookAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

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
