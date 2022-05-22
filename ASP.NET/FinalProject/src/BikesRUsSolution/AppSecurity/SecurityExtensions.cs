using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using AppSecurity.DAL;
using AppSecurity.BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace AppSecurity
{
    public static class SecurityExtensions
    {
        public static void AppSecurityBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<AppSecurityDbContext>(options);

            services.AddTransient<SecurityService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetRequiredService<AppSecurityDbContext>();
                return new SecurityService(context);
            });

        }
    }
}
