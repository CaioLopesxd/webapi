using Microsoft.EntityFrameworkCore;
using webapi.data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load(".env");

var server = Environment.GetEnvironmentVariable("DB_SERVER");
var database = Environment.GetEnvironmentVariable("DB_DATABASE");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Server={server};Database={database};User Id={user};Password={password};";
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();            
    app.UseSwaggerUI();          
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
