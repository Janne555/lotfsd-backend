using Microsoft.EntityFrameworkCore;

namespace Lotfsd.Data.Models
{
  public class LotfsdContext : DbContext
  {

    public LotfsdContext(DbContextOptions<LotfsdContext> options)
      : base(options)
    { }
    public DbSet<CharacterSheet> CharacterSheets { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<Retainer> Retainers { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ItemInstance> ItemInstances { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemEffect> ItemEffects { get; set; }
    public object Where { get; internal set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<User>()
        .Property(x => x.Id)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<CharacterSheet>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<CharacterSheet>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Effect>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<Effect>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Retainer>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<Retainer>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Property>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<Property>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<ItemInstance>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<ItemInstance>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<Item>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<Item>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder.Entity<ItemEffect>()
        .HasIndex(x => x.Guid)
        .IsUnique();

      modelBuilder.HasPostgresExtension("uuid-ossp")
        .Entity<ItemEffect>()
        .Property(x => x.Guid)
        .HasDefaultValueSql("uuid_generate_v4()");
    }
  }
}
