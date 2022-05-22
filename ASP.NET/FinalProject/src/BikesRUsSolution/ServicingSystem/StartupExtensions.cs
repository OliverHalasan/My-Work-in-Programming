using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServicingSystem.DAL;
using ServicingSystem.BLL;


namespace ServicingSystem
{
    public static class StartupExtensions
    {
        public static void AddServicingDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<ServicingDbContext>(options);

            services.AddTransient<ServicingServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetRequiredService<ServicingDbContext>();
                return new ServicingServices(context);
            });

        }
    }
}
