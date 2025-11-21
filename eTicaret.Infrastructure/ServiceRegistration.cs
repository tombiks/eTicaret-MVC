using eTicaret.Domain.Interfaces;
using eTicaret.Infrastructure.Persistence.Context;
using eTicaret.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<eTicaretDbContext>(options =>
            {                
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
                        
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
