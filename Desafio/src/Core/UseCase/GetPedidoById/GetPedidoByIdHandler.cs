using Core.Interfaces;
using Core.Mapping;
using MediatR;
using Microsoft.IdentityModel.SecurityTokenService;

namespace Core.UseCase.GetPedidoById
{
    public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdRequest, GetPedidoByIdResponse>
    {
        private readonly IPedidoRepository _repository;

        public GetPedidoByIdHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPedidoByIdResponse> Handle(GetPedidoByIdRequest request, CancellationToken cancellationToken)
        {
            if (!IsGuid(request.Id)) throw new BadRequestException("Id inválido.");

            var pedido = await _repository.GetPedidoById(request.Id, cancellationToken);

            if (pedido == null) throw new NullReferenceException($"El pedido con Id {request.Id} no existe.");

            return new GetPedidoByIdResponse { Pedido = pedido.ToModel() };
        }

        public static bool IsGuid(Guid id)
        {
            return Guid.TryParse(id.ToString(), out _);
        }
    }
}