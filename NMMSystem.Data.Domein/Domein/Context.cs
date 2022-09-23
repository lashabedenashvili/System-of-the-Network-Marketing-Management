using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein
{
    public class Context :DbContext, IContext
    {
        public DbSet<AddressInfo> AddressInfo { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<PrivateInformation> PrivateInformation { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierRecomendators> SupplierRecomendators { get ; set ; }
        public DbSet<SupplierSale> SupplierSale { get ; set ; }
        public DbSet<Product> Product { get ; set ; }
        public DbSet<SupplierBonusSpecificTime> SupplierBonusSpecificTime { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      

            modelBuilder.Entity<SupplierRecomendators>()
                .HasOne(e => e.RecommendedSupplier)
                .WithMany()
                .HasForeignKey(e => e.RecommendedSupplierId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
