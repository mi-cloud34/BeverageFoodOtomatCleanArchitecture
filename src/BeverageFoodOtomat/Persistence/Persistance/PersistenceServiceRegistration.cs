using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("OtomatConnectionString")));
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IBeverageHotColdTypeRepository, BeverageHotColdTypeRepository>();
            services.AddScoped<IBeverageSugarFreeTypeRepository, BeverageSugarFreeTypeRepository>();
            services.AddScoped<IFoodAqueousAnhydrousTypeRepository, FoodAqueousAnhydrousTypeRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBeverageRepository, BeverageRepository>();
           
            return services;
        }
    }

}
