using CarStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Dal.Ef
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions<CarStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}