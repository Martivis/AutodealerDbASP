using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutodealerDbASP.Models.AutodealerDb.Entities;

namespace AutodealerDbWF
{
    public class AutodealerDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientDeal> ClientDeals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public AutodealerDbContext() : base("AutodealerDbWF")
        {
            Database.SetInitializer(new AutodealerDbInitializer());
            SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarColor>()
                .HasMany(x => x.Models)
                .WithRequired(x => x.CarColor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarBrand>()
                .HasMany(x => x.Models)
                .WithRequired(x => x.CarBrand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(x => x.Lots)
                .WithRequired(x => x.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(x =>  x.Lots)
                .WithRequired(x => x.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lot>()
                .HasMany(x => x.ClientDeals)
                .WithRequired(x => x.Lot)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(x => x.ClientDeals)
                .WithRequired(x => x.Client)
                .WillCascadeOnDelete(false);
                
        }
    }
}
