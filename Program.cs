using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using MVC03.Interface;
using MVC03.Repository;
using MVC03.Data;

var builder = WebApplication.CreateBuilder(args);

// Connection
builder.Services.AddDbContext<MvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcContext") ?? throw new InvalidOperationException("Connection string 'MvcContext' not found.")));
// map Repository
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
