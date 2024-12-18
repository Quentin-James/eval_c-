using Geometrie.DAL;
using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database context
builder.Services.AddDbContext<GeometrieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Geometrie")));

// Register the CercleRepository
builder.Services.AddScoped<CercleRepository>();

// Register the Point_Service

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