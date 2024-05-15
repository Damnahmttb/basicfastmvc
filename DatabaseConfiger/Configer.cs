using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConfiger
{
    public static class Configer
    {
        public static void MaketheConfig(this IServiceCollection collection) 
        {
            collection.AddDbContext<DatabaseContext>(opt=>opt.UseSqlServer("Server=Ahmet;Database=base;Trusted_Connection=True;TrustServerCertificate=True"));
        }
    }
}
