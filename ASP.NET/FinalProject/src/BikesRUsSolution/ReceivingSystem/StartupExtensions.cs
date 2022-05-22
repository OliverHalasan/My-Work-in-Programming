using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ReceivingSystem.DAL;
using ReceivingSystem.BLL;
#endregion

namespace ReceivingSystem
{
    public static class StartupExtensions
    {
        public static void AddReceivingDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<ReceivingDbContext>(options);

            services.AddTransient<ReceivingServices>((serviceProvider) =>
            {
                //get the dbcontext class
                var context = serviceProvider.GetRequiredService<ReceivingDbContext>();
                return new ReceivingServices(context);
            });

        }
    }
}
