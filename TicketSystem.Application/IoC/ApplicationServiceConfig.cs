﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Application.IoC
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection ApplicationServiceConfiguration(this IServiceCollection services)
        {
            ////AutoMapper
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Application
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
