using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DbContextProviderFactory
    {
        
            public static IServiceProvider ServiceProvider { get; }

            static DbContextProviderFactory()
            {
                ServiceCollection sc = new ServiceCollection();
                sc.AddDbContext<TestTaskABContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;"));
                ServiceProvider = sc.BuildServiceProvider();
            }
        
    }
}
