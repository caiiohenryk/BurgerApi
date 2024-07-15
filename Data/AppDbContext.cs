using System.Configuration;
using BurgerApi.Burgers;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Data;

public class AppDbContext : DbContext {
    public DbSet<Burger> Burgers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Essas 'optionsBuilder' só são interessantes em fase de desenvolvimento...
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}