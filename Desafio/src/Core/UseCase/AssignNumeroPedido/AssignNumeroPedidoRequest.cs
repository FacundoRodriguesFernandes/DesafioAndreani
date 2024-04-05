using MediatR;

namespace Core.UseCase.AssignNumeroPedido
{
    public class AssignNumeroPedidoRequest : IRequest<AssignNumeroPedidoResponse>
    {
        public Guid Id { get; set; }
        public long NumeroDePedido { get; set; }
    }
}