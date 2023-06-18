using Core.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using DAL.Repositories;
using Core.Entities.SchoolEntities;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);


string connectionString = "Server=studmysql01.fhict.local;Uid=dbi500555;Database=dbi500555;Pwd=1234";

// Register the connection string
builder.Services.AddSingleton(connectionString);

// Add services to the container.
builder.Services.AddRazorPages();

// Register repositories
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRepository<ReportEntity>, Repository<ReportEntity>>();
builder.Services.AddTransient<IRepository<BaseSchoolEntity>, Repository<BaseSchoolEntity>>();
builder.Services.AddTransient<IRepository<LanguageSchoolEntity>, SchoolRepository<LanguageSchoolEntity>>();
builder.Services.AddTransient<IRepository<STEMSchoolEntity>, SchoolRepository<STEMSchoolEntity>>();
builder.Services.AddTransient<IRepository<SpecializedSchoolEntity>, SchoolRepository<SpecializedSchoolEntity>>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Auth/Login");
    options.AccessDeniedPath = new PathString("/Errors/Unauthorized");
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
