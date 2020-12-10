namespace GuessTheNumber.DAL.Data
{
    using GuessTheNumber.DAL.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .HasOne<IdentityUser>(g => g.GameOwnerUser)
                .WithMany()
                .HasForeignKey(g => g.GameOwnerId);

            modelBuilder.Entity<Game>()
                .HasOne<IdentityUser>(g => g.GameWinnerUser)
                .WithMany()
                .HasForeignKey(g => g.GameWinnerId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Attempts)
                .WithOne()
                .HasForeignKey(a => a.GameId);
        }
    }
}