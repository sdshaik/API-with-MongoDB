using BL.DataManager;
using IObejects;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<EmpStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(EmpStoreDatabaseSettings)));
builder.Services.AddSingleton<IEmpStoreDatabaseSettings>(x => x.GetRequiredService<IOptions<EmpStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("EmpStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IDataRepositroy, EmpManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
