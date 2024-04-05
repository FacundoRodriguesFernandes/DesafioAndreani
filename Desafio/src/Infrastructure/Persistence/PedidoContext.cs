using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedido { get; set; }

        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }
    }
}
