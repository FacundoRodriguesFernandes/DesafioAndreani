using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;

        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public async Task CreatePedido(Pedido pedido, CancellationToken cancellationToken)
        {
            _context.Add(pedido);
            _context.SaveChanges();
        }

        public async Task<Pedido> GetPedidoById(Guid Id, CancellationToken cancellationToken)
        {
            return await _context.Pedido.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        }

        public async Task UpdatePedido(Pedido pedido, CancellationToken cancellationToken)
        {
            _context.Update(pedido);
            _context.SaveChanges();
        }
    }
}