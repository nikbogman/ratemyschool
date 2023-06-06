using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using DAL.Repositories;
using Core.Managers;

var builder = WebApplication.CreateBuilder(args);


string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";

// Register the connection string
builder.Services.AddSingleton(connectionString);

// Add services to the container.
builder.Services.AddRazorPages();

// Register repositories
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<ReviewManager>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/Auth/Login");
    //options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
});
    var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
