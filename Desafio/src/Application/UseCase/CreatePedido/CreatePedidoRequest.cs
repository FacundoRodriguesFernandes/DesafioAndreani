using MediatR;

namespace Application.UseCase.CreatePedido
{
    public class CreatePedidoRequest : IRequest<CreatePedidoResponse>
    {
        public long CurrentAccount { get; set; }
        public long InternalContractCode { get; set; }
    }
}
