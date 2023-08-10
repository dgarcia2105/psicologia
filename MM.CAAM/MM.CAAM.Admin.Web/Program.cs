using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using MM.CAAM.Admin.Services;
using MM.CAAM.Admin.Services.Servicios;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using Unity.Injection;

var builder = WebApplication.CreateBuilder(args);

//// Using the GetValue<type>(string key) method
//var configValue = builder.Configuration.GetValue<string>("Authentication:CookieAuthentication:LoginPath");

// or using the index property (which always returns a string)
var BaseUrlApiCentralActuarios = builder.Configuration["BaseUrlWebApiCaam"];
var ApiKeyCentralActuarios = builder.Configuration["ApiKeyCaam"];

#region SERVICES
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRESTService, RESTService>(); /*new InjectionConstructor(ApiKeyCentralActuarios, BaseUrlApiCentralActuarios)*/
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();
#endregion

#region COOKIES
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
//}).AddCookie(IdentityConstants.ApplicationScheme);
//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = ".AdventureWorks.Session";
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.IsEssential = true;
//});
#endregion


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

////part cookies
//app.UseAuthentication();
//app.UseSession();

app.UseAuthorization();

//Pagina de inicio HOME INDEX
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loggin}/{action=Index}/{id?}");
//pattern: "{controller=Usuario}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}"); OLD

app.Run();
