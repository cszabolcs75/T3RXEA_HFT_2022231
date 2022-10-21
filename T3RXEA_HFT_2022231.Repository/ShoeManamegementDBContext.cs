using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Repository
{
    public class ShoeManamegementDBContext: DbContext
    {
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        public ShoeManamegementDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|/ShoeManagementDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.HasOne(brand => brand.brands).WithMany(shoes => shoes.shoes).HasForeignKey(brand=>brand.BrandId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.HasOne(sport => sport.sports).WithMany(shoes => shoes.shoes).HasForeignKey(sport => sport.SportId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasOne(sport => sport.sports).WithMany(brand => brand.brands).HasForeignKey(sport => sport.SuggestedSportId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
