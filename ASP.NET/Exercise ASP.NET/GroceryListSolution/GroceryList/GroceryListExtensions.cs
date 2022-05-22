using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GroceryList.DAL;
using GroceryList.BLL;

namespace GroceryList
{
    public static class ListExtensions
    {
        public static void GroceryListBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<GrocerylistContext>(options);

            services.AddTransient<CategoryServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<GrocerylistContext>();
                return new CategoryServices(context);
            });
            services.AddTransient<ProductServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<GrocerylistContext>();
                return new ProductServices(context);
            });

        }
    }
}
