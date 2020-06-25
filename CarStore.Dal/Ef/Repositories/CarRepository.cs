using CarStore.Dal.Entities;
using CarStore.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Dal.Ef.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarStoreDbContext context)
            : base(context) { }
    }
}
