// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using Microsoft.EntityFrameworkCore;
using Proekt.Models;

var builder = WebApplication.CreateBuilder(args);
string con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<CinemaContext>();



//builder.Services.AddDbContext<CinemaContext>(option => option.UseNpgsql);




// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Add}/{action=add}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Filmi}/{action=Index1}/{id?}");
app.Run();
