using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using server.Data;
using server.Middlewares;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Ensure the database is created
new InventoryDbContext().Database.EnsureCreated();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c) =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Small Inventory System", Version = "v1.0" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddSingleton<InventoryDbContext>();

builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<SupplierService>();
builder.Services.AddTransient<ExceptionMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();
app.MapControllers();

app.Run();