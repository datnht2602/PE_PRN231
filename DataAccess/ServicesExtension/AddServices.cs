using DataAccess.Container;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ServicesExtension
{
    public static class AddServices
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services) 
        { 
            services.AddScoped<IMuseumsRepository,MuseumsRepository>();
            services.AddScoped<IUsersRepository,UsersRepository>();
            services.AddScoped<IArtworksRepository,ArtworksRepository>();
            return services;
        }
    }
}
