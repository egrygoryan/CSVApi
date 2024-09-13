namespace CSVApi.Data.Context;

public class ManagerContext(DbContextOptions<ManagerContext> options) : DbContext(options)
{
    public DbSet<Manager> Managers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
