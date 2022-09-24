using Energo.Domain.Interfaces;
using Energo.Infrastructure.Business;
using Energo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<EnergoContext>();
//builder.Services.AddDbContext<EnergoContext>(x => x.UseSqlite("Data Source=energo1.db"));

//builder.Services.AddSingleton<IEnergoRepository, EnergoRepository>();
builder.Services.AddTransient<IBusinessLogic, EnergoBusinessLogic>();





//optionsBuilder.UseSqlite(Configuration["ConnectionStrings:SqLiteDB"]);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
