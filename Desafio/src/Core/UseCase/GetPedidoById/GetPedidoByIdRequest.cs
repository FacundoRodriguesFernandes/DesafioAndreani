using MediatR;

namespace Core.UseCase.GetPedidoById
{
    public class GetPedidoByIdRequest : IRequest<GetPedidoByIdResponse>
    {
        public Guid Id { get; set; }
    }
}