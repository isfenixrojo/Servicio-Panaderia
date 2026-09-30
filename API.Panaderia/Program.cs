using API.Panaderia.Core.Interfaces;
using API.Panaderia.Core.Repository;
using API.Panaderia.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

#region Area de servicios 
builder.Services.AddDbContext<ApplicationDbContext>(opcions => opcions.UseSqlServer("name=ConnPan"));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPanRepository, PanRepository>();

#endregion Area de servicios 

var app = builder.Build();

#region Area de Middleware

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt => {
        opt.Title = "WebApi with Scalar Example";
        opt.Theme = ScalarTheme.BluePlanet;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

app.MapControllers();
#endregion Area de Middleware
app.Run();
