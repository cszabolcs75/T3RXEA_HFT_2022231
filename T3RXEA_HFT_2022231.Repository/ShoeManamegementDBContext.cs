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
                entity.HasOne(brand => brand.brands).WithMany(shoe => shoe.shoes).HasForeignKey(brand=>brand.BrandId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.HasOne(sport => sport.sports).WithMany(shoe => shoe.shoes).HasForeignKey(sport => sport.SportId).OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasOne(sport => sport.sports).WithMany(brand => brand.brands).HasForeignKey(sport => sport.SuggestedSportId).OnDelete(DeleteBehavior.ClientCascade);
            });

            Sport soccer = new Sport() { Id=1, Description = "football", Inventor = "Unknown", IsOlimpic = true, Name = "Soccer" };
            Sport basketball = new Sport() { Id=2, Description = "basketball", Inventor = "James Naismith", IsOlimpic = true, Name = "Basketball" };
            Sport Handball = new Sport() { Id = 3, Description = "handball", Inventor = "Holger Nielson", IsOlimpic = true, Name = "Handball" };
            //3 sport
            
            Brand nike = new Brand() { Id = 1, Name = "Nike", Owner = "Phil Knight", Manufacturer = "Nike.Inc", SuggestedSportId = 1 };
            Brand adidas = new Brand() { Id = 2, Name = "Adidas", Owner = "Adolf Dassler", Manufacturer = "Adidas.Inc", SuggestedSportId = 1 };
            Brand underarmor = new Brand() { Id = 3, Name = "Underarmor", Owner = "Kevin Plank", Manufacturer = "Underarmor.Inc", SuggestedSportId = 1 };
            Brand puma = new Brand() { Id=4, Name="Puma", Owner= "Artemis S.A", Manufacturer="Puma.Inc", SuggestedSportId=2};
            Brand reebok = new Brand() { Id = 5, Name = "Reebok", Owner = "Joe and Jeff Foster", Manufacturer = "Reebok.Inc", SuggestedSportId = 2 };
            Brand asics = new Brand() { Id = 6, Name = "ASICS", Owner = "Kihachiro Onitsuka", Manufacturer = "ASICS.Inc", SuggestedSportId = 2 };
            Brand hummel = new Brand() { Id = 7, Name = "Hummel", Owner = "Thornico A/S", Manufacturer = "Hummel.Inc", SuggestedSportId = 3 };
            Brand mizuno = new Brand() { Id = 8, Name = "Mizuno", Owner = "Rihachi Mizuno", Manufacturer = "Mizuno.Inc", SuggestedSportId = 3 };
            Brand kempa = new Brand() { Id = 9, Name = "Kempa", Owner = "Bernhard Kempa", Manufacturer = "Kempa.Inc", SuggestedSportId = 3 };

            //9 brand
            
            Shoe nike1 = new Shoe() { Id = 1, Prize = 12000, Name = "Nike Phantom GT2 Elite", SportId = 1, BrandId = 1 };
            Shoe nike2 = new Shoe() { Id = 2, Prize = 22000, Name = "Nike KD15", SportId = 2, BrandId = 1 };
            Shoe nike3 = new Shoe() { Id = 3, Prize = 41200, Name = "Nike Kyrie Infinity", SportId = 3, BrandId = 1 };
            Shoe adidas1 = new Shoe() { Id = 4, Prize = 16800, Name = "adidas Predator Pulse", SportId = 1, BrandId = 2 };
            Shoe adidas2 = new Shoe() { Id = 5, Prize = 53400, Name = "adidas Dame 8", SportId = 2, BrandId = 2 };
            Shoe adidas3 = new Shoe() { Id = 6, Prize = 24300, Name = "adidas Stabil Next Gen", SportId = 3, BrandId = 2 };
            Shoe underarmor1 = new Shoe() { Id = 7, Prize = 32462, Name = "UA HOVR Phantom 3", SportId = 1, BrandId = 3 };
            Shoe underarmor2 = new Shoe() { Id = 8, Prize = 27226, Name = "Under Armour Curry Flow 8", SportId = 2, BrandId = 3 };
            Shoe underarmor3 = new Shoe() { Id = 9, Prize = 72634, Name = "Project Rock 5", SportId = 3, BrandId = 3 };
            Shoe puma1 = new Shoe() { Id = 10, Prize = 33251, Name = "Puma Wild Rider Grip LS Black", SportId = 1, BrandId = 4 };
            Shoe puma2 = new Shoe() { Id = 11, Prize = 62353, Name = "PUMA Cell King Rhude", SportId = 2, BrandId = 4 };
            Shoe puma3 = new Shoe() { Id = 12, Prize = 72346, Name = "PUMA Rise NITRO Basketball Shoes", SportId = 3, BrandId = 4 };
            Shoe reebok1 = new Shoe() { Id = 13, Prize = 98567, Name = "REEBOK ANSWER IV SHOES", SportId = 1, BrandId = 5 };
            Shoe reebok2 = new Shoe() { Id = 14, Prize = 13245, Name = "REEBOK SHAQNOSIS BASKETBALL", SportId = 2, BrandId = 5 };
            Shoe reebok3 = new Shoe() { Id = 15, Prize = 87652, Name = "REEBOK QUESTION MID SHOES", SportId = 3, BrandId = 5 };
            Shoe asics1 = new Shoe() { Id = 16, Prize = 89234, Name = "Asics ROADBLAST", SportId = 1, BrandId = 6 };
            Shoe asics2 = new Shoe() { Id = 17, Prize = 97239, Name = "Asics GT-1000", SportId = 2, BrandId = 6 };
            Shoe asics3 = new Shoe() { Id = 18, Prize = 13256, Name = "Asics NETBURNER BALLISTIC FF 3", SportId = 3, BrandId = 6 };
            Shoe hummel1 = new Shoe() { Id = 19, Prize = 36542, Name = "HUMMEL Reach Lx 6000", SportId = 1, BrandId = 7 };
            Shoe hummel2 = new Shoe() { Id = 20, Prize = 33165, Name = "HUMMEL Slimmer Stadil High 63511-9228", SportId = 2, BrandId = 7 };
            Shoe hummel3 = new Shoe() { Id = 21, Prize = 55312, Name = "HUMMEL AEROCHARGE FUSION STZ 207307-2001", SportId = 3, BrandId = 7 };
            Shoe mizuno1 = new Shoe() { Id = 22, Prize = 66412, Name = "MIZUNO Wave Rider 26", SportId = 1, BrandId = 8 };
            Shoe mizuno2 = new Shoe() { Id = 23, Prize = 55211, Name = "MIZUNO Wave Sky 6", SportId = 2, BrandId = 8 };
            Shoe mizuno3 = new Shoe() { Id = 24, Prize = 55422, Name = "MIZUNO Wave Shadow 5", SportId = 3, BrandId = 8 };
            Shoe kempa1 = new Shoe() { Id = 25, Prize = 66991, Name = "Kempa WING LITE 2.0", SportId = 1, BrandId = 9 };
            Shoe kempa3 = new Shoe() { Id = 27, Prize = 99331, Name = "Kempa ATTACK THREE 2.0", SportId = 2, BrandId = 9 };
            Shoe kempa2 = new Shoe() { Id = 26, Prize = 11668, Name = "Kempa Attack Contender", SportId = 3, BrandId = 9 };
            //27 shoe 

            modelBuilder.Entity<Sport>().HasData(soccer);
            modelBuilder.Entity<Sport>().HasData(basketball);
            modelBuilder.Entity<Sport>().HasData(Handball);
            
            modelBuilder.Entity<Brand>().HasData(nike);
            modelBuilder.Entity<Brand>().HasData(adidas);
            modelBuilder.Entity<Brand>().HasData(underarmor);
            modelBuilder.Entity<Brand>().HasData(puma);
            modelBuilder.Entity<Brand>().HasData(reebok);
            modelBuilder.Entity<Brand>().HasData(asics);
            modelBuilder.Entity<Brand>().HasData(hummel);
            modelBuilder.Entity<Brand>().HasData(mizuno);
            modelBuilder.Entity<Brand>().HasData(kempa);


            modelBuilder.Entity<Shoe>().HasData(nike1);
            modelBuilder.Entity<Shoe>().HasData(nike2);
            modelBuilder.Entity<Shoe>().HasData(nike3);
            modelBuilder.Entity<Shoe>().HasData(adidas1);
            modelBuilder.Entity<Shoe>().HasData(adidas2);
            modelBuilder.Entity<Shoe>().HasData(adidas3);
            modelBuilder.Entity<Shoe>().HasData(underarmor1);
            modelBuilder.Entity<Shoe>().HasData(underarmor2);
            modelBuilder.Entity<Shoe>().HasData(underarmor3);
            modelBuilder.Entity<Shoe>().HasData(puma1);
            modelBuilder.Entity<Shoe>().HasData(puma2);
            modelBuilder.Entity<Shoe>().HasData(puma3);
            modelBuilder.Entity<Shoe>().HasData(reebok1);
            modelBuilder.Entity<Shoe>().HasData(reebok2);
            modelBuilder.Entity<Shoe>().HasData(reebok3);
            modelBuilder.Entity<Shoe>().HasData(asics1);
            modelBuilder.Entity<Shoe>().HasData(asics2);
            modelBuilder.Entity<Shoe>().HasData(asics3);
            modelBuilder.Entity<Shoe>().HasData(hummel1);
            modelBuilder.Entity<Shoe>().HasData(hummel2);
            modelBuilder.Entity<Shoe>().HasData(hummel3);
            modelBuilder.Entity<Shoe>().HasData(mizuno1);
            modelBuilder.Entity<Shoe>().HasData(mizuno2);
            modelBuilder.Entity<Shoe>().HasData(mizuno3);
            modelBuilder.Entity<Shoe>().HasData(kempa1);
            modelBuilder.Entity<Shoe>().HasData(kempa2);
            modelBuilder.Entity<Shoe>().HasData(kempa3);  
        }
    }
}
