using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using La_Mia_Pizzeria_1.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder (args);

builder.Services.AddDbContext<BlogContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BlogContext>();

// Add services to the container.
builder.Services.AddControllersWithViews ();

var mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build ();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment ()) {
	app.UseExceptionHandler ("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts ();
}

app.UseHttpsRedirection ();
app.UseStaticFiles ();

app.UseRouting ();

app.UseAuthentication();

app.UseAuthorization ();

app.MapControllerRoute (
	name: "default",
	pattern: "{controller=Pizza}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run ();

