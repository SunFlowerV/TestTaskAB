using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.UserDateAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class ServiceProviderFactorys
    {
        public static IServiceProvider ServiceProvider { get; }

        static ServiceProviderFactorys()
        {
            ServiceCollection sc = new ServiceCollection();
            sc.AddScoped<IUserDateAccess, UserDateAccess>();
            ServiceProvider = sc.BuildServiceProvider();
        }
    }
}
