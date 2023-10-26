using server.Services;
using server.Middlewares;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Database Connection
        var dbc = new DatabaseConnection
        {
            Host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost",
            Port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432",
            Username = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "myusername",
            Password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "mypassword",
            Database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "inventory_system"
        };

        builder.Services.AddSingleton<DatabaseService>(new DatabaseService(dbc));

        // Add services to the container.

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

        app.UseMiddleware<GlobalErrorHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
