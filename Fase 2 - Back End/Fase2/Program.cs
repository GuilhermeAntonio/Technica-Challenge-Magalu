using Fase2.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

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
