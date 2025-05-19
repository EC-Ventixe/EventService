using Microsoft.EntityFrameworkCore;
using WebAPI.Entites;

namespace WebAPI.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
