using CarStore.Bll.Services;
using CarStore.Bll.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.WebApi.Infrastructure.ServiceExtensions
{
    public static class BllServiceExtensions
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddTransient<ICarService, CarService>();

            return services;
        }
    }
}
