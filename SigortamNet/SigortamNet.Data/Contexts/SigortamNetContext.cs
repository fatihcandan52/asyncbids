using Microsoft.EntityFrameworkCore;
using SigortamNet.Data.Entities;
using SigortamNet.Data.Extensions;

namespace SigortamNet.Data.Contexts
{
    public class SigortamNetContext : DbContext
    {
        public SigortamNetContext(DbContextOptions<SigortamNetContext> options) : base(options)
        { 
           //Database.EnsureCreated();
        }

        public DbSet<PartnerEntity> Partners { get; set; }
        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<BidEntity> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfiguration();
            modelBuilder.AddSeedData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
