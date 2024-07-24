using Microsoft.EntityFrameworkCore;
using NoriuValgyti.Domain.Entities;
using NoriuValgyti.Infrastructure.Data.Configurations;

namespace NoriuValgyti.Infrastructure.Data;

public class NoriuValgytiDataContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Recipe> Recipes { get; set; }
    

    public NoriuValgytiDataContext(DbContextOptions<NoriuValgytiDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }
}