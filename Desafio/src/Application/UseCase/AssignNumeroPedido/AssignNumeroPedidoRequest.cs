using MediatR;

namespace Application.UseCase.AssignNumeroPedido
{
    public class AssignNumeroPedidoRequest : IRequest<AssignNumeroPedidoResponse>
    {
        public Guid Id { get; set; }
        public long NumeroDePedido { get; set; }
    }
}