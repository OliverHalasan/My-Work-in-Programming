using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SalesSystem.DAL;
using SalesSystem.BLL;
//using PurchasingSystem.BLL;

namespace ServicingSystem
{
    public static class StartupExtensions
    {
        public static void AddSalesDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<SalesDbContext>(options);
            services.AddTransient<SalesSystemServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<SalesDbContext>();
                return new SalesSystemServices(context);
            });

        }
    }
}
