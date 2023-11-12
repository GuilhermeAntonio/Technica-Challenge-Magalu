using Fase_3.Data;
using Fase3.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{

    options.Cookie.Name = "Session";
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    

});

builder.Services.AddScoped<IAuthenticationUserService, AuthenticationUserService>();

builder.Services.AddDbContext<ApplicationDbcontext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginPanel}/{action=Index}/{id?}"
);

app.UseStatusCodePagesWithReExecute("/LoginPanel/Index");
app.UseExceptionHandler("/LoginPanel/Index");
app.UseHsts();

app.Run();  
