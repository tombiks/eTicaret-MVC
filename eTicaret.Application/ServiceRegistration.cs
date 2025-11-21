using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using eTicaret.Application.Interfaces;
using eTicaret.Application.Services;

namespace eTicaret.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();
        }
    
    }
}
