using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PurchasingSystem.DAL;
using PurchasingSystem.BLL;

namespace PurchasingSystem
{
    public static class StartupExtensions
    {
        public static void AddPurchasingDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<PurchasingDbContext>(options);

            services.AddTransient<VendorService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetRequiredService<PurchasingDbContext>();
                return new VendorService(context);
            });
            services.AddTransient<PurchaseOrderService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetRequiredService<PurchasingDbContext>();
                return new PurchaseOrderService(context);
            });

        }
    }
}
