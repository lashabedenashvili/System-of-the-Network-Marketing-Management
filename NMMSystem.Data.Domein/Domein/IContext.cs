using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein
{
    public interface IContext
    {
        DbSet<AddressInfo> AddressInfo { get;set;}
        DbSet<ContactInformation> ContactInformation { get; set; }
        DbSet<PrivateInformation> PrivateInformation { get; set; }
        DbSet<Supplier> Supplier { get; set; }
        DbSet<SupplierRecomendators> SupplierRecomendators { get; set; }
       DbSet<SupplierSale> SupplierSale { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<SupplierBonusSpecificTime> SupplierBonusSpecificTime { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();


    }
}
