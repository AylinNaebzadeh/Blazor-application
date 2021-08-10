using Microsoft.EntityFrameworkCore;
using BlazorDB.Server.Controllers;
using BlazorDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.Shared.Models;

namespace BlazorDB.Server.DB
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {}
        public DbSet<Product> Products {get; set;}

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}