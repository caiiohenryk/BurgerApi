using System.Configuration;
using BurgerApi.Burgers;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Data;

public class AppDbContext : DbContext {
    public DbSet<Burger> Burgers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=Banco.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}