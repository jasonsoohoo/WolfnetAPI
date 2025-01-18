using Microsoft.EntityFrameworkCore;
using WolfnetAPI.Data;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
connectionString += $"Password={builder.Configuration["ConnectionStrings:DefaultConnection:Password"]}";

builder.Services.AddDbContext<MatchDbContext>(options =>
    options.UseNpgsql(connectionString));

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
