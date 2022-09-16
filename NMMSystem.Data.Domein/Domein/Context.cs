using Microsoft.EntityFrameworkCore;
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
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
