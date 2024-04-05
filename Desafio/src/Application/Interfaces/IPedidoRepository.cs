using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPedidoRepository
    {
        Task CreatePedido(Pedido pedido, CancellationToken cancellationToken);

        Task UpdatePedido(Pedido pedido, CancellationToken cancellationToken);

        Task<Pedido> GetPedidoById(Guid Id, CancellationToken cancellationToken);
    }
}