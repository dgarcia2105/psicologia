using Microsoft.AspNetCore.Builder;
using MM.CAAM.Gestion.Models;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

//Configuracion para guardar todas las respuestas del WebApi
var servicioLogger = (ILogger<Startup>)app.Services.GetService(typeof(ILogger<Startup>));

startup.Configure(app, app.Environment, servicioLogger);

app.Run();

