using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.Configurations;
using Persistance.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class AppDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            #region ApplyConfiguration

            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ApplyEntityConfiguration
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            #endregion

            #region ApplySeeds
            modelBuilder.ApplyConfiguration(new BrandSeed());
            #endregion
        }
    }
    }
