using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using MM.CAAM.Admin.Services;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Admin.Web;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using Unity.Injection;



var builder = WebApplication.CreateBuilder(args);


var BaseUrlApiCentralActuarios = builder.Configuration["BaseUrlWebApiCaam"];
var ApiKeyCentralActuarios = builder.Configuration["ApiKeyCaam"];

#region CACHE
builder.Services.AddResponseCaching();
#endregion 

#region COOKIES

//README: https://www.codeguru.com/dotnet/asp-net-cookies/
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#region FILTROS PERSONALIZADOS
builder.Services.AddTransient<CheckSessionOut>();
#endregion

//README: https://www.youtube.com/watch?v=Y-JMOHKCkCk
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
});

//README: Asignando una session cookie al registrar un usuario. https://www.udemy.com/course/aprende-aspnet-core-mvc-haciendo-proyectos-desde-cero/learn/lecture/29610340#questions
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
//}).AddCookie(IdentityConstants.ApplicationScheme);

// vipp - https://www.google.com/search?sca_esv=557804163&rlz=1C1CHBF_esMX992MX992&sxsrf=AB5stBhOGTVth9rpmSxiO9nxWYw40mDbVw:1692296443701&q=login+web+cookies+.net+core+6+example&tbm=vid&source=lnms&sa=X&ved=2ahUKEwiOoIbDp-SAAxXkJkQIHVusDdcQ0pQJegQIChAB&biw=1920&bih=937&dpr=1#fpstate=ive&vld=cid:77432373,vid:rODKID5XiP8
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.LoginPath= "/Home/Login";
        //o.Events = new CookieAuthenticationEvents
        //{
        //    OnSignedIn = async ctx =>
        //    {
        //        ctx.HttpContext.User = ctx.Principal;
        //    }
        //};
    });

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

#region CACHE
app.UseResponseCaching();
#endregion 

#region cookies
app.UseAuthentication(); 
#endregion

app.UseAuthorization();

//Pagina de inicio HOME INDEX
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}");
    //pattern: "{controller=Loggin}/{action=Index}/{id?}");
//pattern: "{controller=Usuario}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}"); OLD

app.Run();
