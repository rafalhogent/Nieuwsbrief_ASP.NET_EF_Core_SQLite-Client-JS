using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SubscriberDbContext : DbContext
    {
        public SubscriberDbContext() { }
        public SubscriberDbContext(DbContextOptions<SubscriberDbContext> options) : base(options) { }

        public DbSet<Subscriber> Subscribers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>().ToTable("Subscribers");
            modelBuilder.Entity<Subscriber>().HasData(new Subscriber("johnsmith@example.com"));
            base.OnModelCreating(modelBuilder);
        }
    }
}