using Core.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddDbContext<PedidoContext>(options =>
                options.UseSqlServer(@"Server=DESKTOP-VP14FSD\SQLEXPRESS;Database=Desafio ;Trusted_Connection=SSPI;Trust Server Certificate=true"));

            return services;
        }
    }
}