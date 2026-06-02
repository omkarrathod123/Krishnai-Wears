using Microsoft.EntityFrameworkCore;

public class KrishnaiWearsContext(DbContextOptions<KrishnaiWearsContext> options) : DbContext(options)
{
    public DbSet<KrishnaiWears.Model.Product> Product { get; set; } = default!;
}
