using webAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using webAPI.Data.Repo;
using webAPI.Controllers;
using webAPI.Data.Interfaces;
using webAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
  builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork> ();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
// app.Use((context, next) =>
// {
//     context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
//     context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
//     context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
//     return next();
// });
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
