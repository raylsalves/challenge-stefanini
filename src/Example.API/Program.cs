using Microsoft.EntityFrameworkCore;
using Stefanini.Challenge.Application.Services;
using Stefanini.Challenge.Application.Services.Interfaces;
using Stefanini.Challenge.Domain;
using Stefanini.Challenge.Infra.Data;
using Stefanini.Challenge.Infra.Data.Repositories;
using Stefanini.Challenge.Infra.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMappers();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericReposity<>));
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dataContext.Database.Migrate();
}

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();

