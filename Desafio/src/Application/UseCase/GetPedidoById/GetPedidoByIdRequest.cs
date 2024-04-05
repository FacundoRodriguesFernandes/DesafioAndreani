using MediatR;

namespace Application.UseCase.GetPedidoById
{
    public class GetPedidoByIdRequest : IRequest<GetPedidoByIdResponse>
    {
        public Guid Id { get; set; }
    }
}