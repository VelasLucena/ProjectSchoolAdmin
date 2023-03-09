using Microsoft.EntityFrameworkCore;
using ProjectApi.Context;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; 

builder.Services.AddControllers();

builder.Services.AddDbContext<SystemContext>(opt =>
        opt.UseMySql(configuration.GetConnectionString("System"), new MySqlServerVersion(new Version(8, 0, 27)))
        );

builder.Services.AddDbContext<ProfileContext>(opt =>
        opt.UseMySql(configuration.GetConnectionString("Profile"), new MySqlServerVersion(new Version(8, 0, 27)))
        );

builder.Services.AddMvc();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}/{id}",
    defaults: new { id = RouteParameter.Optional, Action = RouteParameter.Optional } );

app.UseAuthorization();

app.MapControllers();

app.Run();
