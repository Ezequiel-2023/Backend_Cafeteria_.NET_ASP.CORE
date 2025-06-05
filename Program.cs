using Inventory.Config;
using Inventory.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TodoContext");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La conexion string 'TodoContext' no existe.");
}

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseMySQL(connectionString));

// Add services to the container.
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<UserService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
