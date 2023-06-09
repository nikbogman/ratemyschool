using Core.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using DAL.Repositories;
using Core.Managers;
using Core.Managers.SchoolManagers;
using DAL.Repositories.SchoolRepositories;
using Core.Entities.SchoolEntities;
using Core.FeatureManagers;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);


string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";

// Register the connection string
builder.Services.AddSingleton(connectionString);

// Add services to the container.
builder.Services.AddRazorPages();

// Register repositories
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRepository<ReportEntity>, BaseRepository<ReportEntity>>();
builder.Services.AddTransient<IRepository<BaseSchoolEntity>, BaseRepository<BaseSchoolEntity>>();
builder.Services.AddTransient<IRepository<LanguageSchoolEntity>, LanguageSchoolRepository>();
builder.Services.AddTransient<IRepository<STEMSchoolEntity>, STEMSchoolRepository>();
builder.Services.AddTransient<IRepository<SpecializedSchoolEntity>, SpecializedSchoolRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Auth/Login");
    options.AccessDeniedPath = new PathString("/Errors/Unauthorized");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{

//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
