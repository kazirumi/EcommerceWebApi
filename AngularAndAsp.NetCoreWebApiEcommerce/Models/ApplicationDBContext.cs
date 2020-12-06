using AngularAndAsp.NetCoreWebApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAsp.NetCoreWebApiEcommerce
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<SpecialTag> SpecialTag { get; set; }
        public DbSet<QuantityType> QuantityType { get; set; }

        public DbSet<Product> Product { get; set; }




    }


}
