using CarStore.Dal.Ef;
using CarStore.Dal.Ef.Repositories;
using CarStore.Dal.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.WebApi.Infrastructure.ServiceExtensions
{
    public static class EfDalServiceExtensions
    {
        public static IServiceCollection AddEfDal(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<CarStoreDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("CarStoreDbConnectionString")));

            services.AddTransient<ICarRepository, CarRepository>();

            return services;
        }

        public static void CreateEfDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CarStoreDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
