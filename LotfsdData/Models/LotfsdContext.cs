using Microsoft.EntityFrameworkCore;

namespace Lotfsd.Data.Models
{
  public class LotfsdContext : DbContext
  {
    public DbSet<CharacterSheet> CharacterSheets { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<Retainer> Retainers { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ItemInstance> ItemInstances { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
            "Server = (localdb)\\mssqllocaldb; Database = Lotfsd; Trusted_Connection = True; ");
    }
  }
}
