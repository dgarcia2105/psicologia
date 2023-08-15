using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using MM.CAAM.Admin.Services;
using MM.CAAM.Admin.Services.Servicios;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using Unity.Injection;



var builder = WebApplication.CreateBuilder(args);


var BaseUrlApiCentralActuarios = builder.Configuration["BaseUrlWebApiCaam"];
var ApiKeyCentralActuarios = builder.Configuration["ApiKeyCaam"];


#region COOKIES

//README: https://www.codeguru.com/dotnet/asp-net-cookies/
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//README: https://www.youtube.com/watch?v=Y-JMOHKCkCk
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
});

//README: Asignando una session cookie al registrar un usuario. https://www.udemy.com/course/aprende-aspnet-core-mvc-haciendo-proyectos-desde-cero/learn/lecture/29610340#questions
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
}).AddCookie(IdentityConstants.ApplicationScheme);
#endregion

#region SERVICES
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRESTService, RESTService>(); /*new InjectionConstructor(ApiKeyCentralActuarios, BaseUrlApiCentralActuarios)*/
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();
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

#region cookies/session
app.UseSession();
#endregion

app.UseRouting();

#region cookies
app.UseAuthentication();
#endregion

app.UseAuthorization();

//Pagina de inicio HOME INDEX
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loggin}/{action=Index}/{id?}");
//pattern: "{controller=Usuario}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}"); OLD

app.Run();
