using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
  public class DatabaseConnection
  {
    public string Host { get; set; } = "localhost";
    public string Port { get; set; } = "5432";
    public string Username { get; set; } = "myusernames";
    public string Password { get; set; } = "mypassword";
    public string Database { get; set; } = "inventory_system";

    public override string ToString()
    {
      return $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database}";
    }
  }
  public class InventoryDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(new DatabaseConnection()
      {
        Host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost",
        Port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432",
        Username = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "myusername",
        Password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "mypassword",
        Database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "inventory_system"
      }.ToString());
    }

    public DbSet<Product>? Products { get; set; } = null;
    public DbSet<Supplier>? Suppliers { get; set; } = null;
  }
}