using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PedidoContext(DbContextOptions<PedidoContext> options) : DbContext(options)
    {
        public DbSet<Pedido> Pedido { get; set; }
    }
}