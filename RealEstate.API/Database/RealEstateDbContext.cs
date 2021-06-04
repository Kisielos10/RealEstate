using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.API.Persistence;

namespace RealEstate.API
{
    public class RealEstateDbContext : DbContext
    {
        public DbSet<Persistence.RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateAddress> RealEstateAddresses { get; set; }
        public DbSet<RealEstateNote> RealEstateNotes { get; set; }
        public DbSet<Image> Images { get; set; }

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Persistence.RealEstate>()
                .Property(e => e.BuildingType)
                .HasConversion<string>();
        }

    }
}
