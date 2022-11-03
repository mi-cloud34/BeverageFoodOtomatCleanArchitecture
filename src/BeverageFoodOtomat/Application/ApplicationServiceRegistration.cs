
using Application.Features.Beverages.Rules;
using Application.Features.Customers.Rules;
using Application.Features.FoodAqueousAnhydrousTypes.Rules;
using Application.Features.Foods.Rules;
using Application.Features.Payments.Rules;
using Application.Features.PaymentTypes.Rules;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<BeverageBusinessRules>();
            services.AddScoped<PaymentBusinessRules>();
            services.AddScoped<PaymentTypeBusinessRules>();
            services.AddScoped<CustomerBusinessRules>();
            services.AddScoped<FoodBusinessRules>();
            services.AddScoped<FoodAqueousAnhydrousTypeBusinessRules>();
           
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            


            return services;

        }
    }
}