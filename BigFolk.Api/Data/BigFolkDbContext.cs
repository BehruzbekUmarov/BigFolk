using BigFolk.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Data
{
    public class BigFolkDbContext : DbContext
    {
        public BigFolkDbContext(DbContextOptions<BigFolkDbContext> options) : base(options)
        {}

        public DbSet<Genius> Geniuses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HouseSystem> HouseSystems { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SmartHouse> SmartHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One To Many relationship
            modelBuilder.Entity<Genius>()
                .HasMany(e => e.Cars)
                .WithOne(u => u.Genius)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();
            modelBuilder.Entity<Car>()
                .HasOne(e => e.Genius)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();

            modelBuilder.Entity<Genius>()
                .HasMany(e => e.SmartHouses)
                .WithOne(u => u.Genius)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();
            modelBuilder.Entity<SmartHouse>()
                .HasOne(e => e.Genius)
                .WithMany(u => u.SmartHouses)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();

            modelBuilder.Entity<Genius>()
                .HasMany(e => e.Companies)
                .WithOne(u => u.Genius)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();
            modelBuilder.Entity<Company>()
                .HasOne(e => e.Genius)
                .WithMany(u => u.Companies)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();

            modelBuilder.Entity<Genius>()
                .HasMany(e => e.Habits)
                .WithOne(u => u.Genius)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();
            modelBuilder.Entity<Habit>()
                .HasOne(e => e.Genius)
                .WithMany(u => u.Habits)
                .HasForeignKey(c => c.GeniusId)
                .IsRequired();

            // One To One relationship
            modelBuilder.Entity<SmartHouse>()
                .HasOne(e => e.HouseSystem)
                .WithOne(u => u.SmartHouse)
                .HasForeignKey<HouseSystem>(c => c.SmartHouseId)
                .IsRequired();
            modelBuilder.Entity<HouseSystem>()
                .HasOne(e => e.SmartHouse)
                .WithOne(u => u.HouseSystem)
                .HasForeignKey<HouseSystem>(c => c.SmartHouseId)
                .IsRequired();

            // Many To Manyrelationship
            modelBuilder.Entity<Portfolio>(x => x.HasKey(p => new { p.GeniusId, p.SkillId }));

            modelBuilder.Entity<Portfolio>()
                .HasOne(e => e.Genius)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(x => x.GeniusId);

            modelBuilder.Entity<Portfolio>()
                .HasOne(e => e.Skill)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(x => x.SkillId);
        }
    }
}
