using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server;

public interface IDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Supplier> Suppliers { get; set; }

    int SaveChanges();
}

public class PostgresDbContext : DbContext, IDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
        Products = Set<Product>();
        Suppliers = Set<Supplier>();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfig());
    }
}