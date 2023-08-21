using HrPlatform.Entities.IUnitOfWork;
using HrPlatform.Entities.Repositories;
using HrPlatform.Entities.Service;
using HrPlatform.Service;
using HrPLatform.DataAccessLayer;
using HrPLatform.DataAccessLayer.RepositoryDAL;
using HrPLatform.DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Services<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<HrDBConnection>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppContext")));


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
