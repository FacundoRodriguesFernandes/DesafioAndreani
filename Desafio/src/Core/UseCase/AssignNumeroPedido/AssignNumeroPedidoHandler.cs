using Core.Interfaces;
using Core.Mapping;
using MediatR;
using Microsoft.IdentityModel.SecurityTokenService;

namespace Core.UseCase.AssignNumeroPedido
{
    public class AssignNumeroPedidoHandler : IRequestHandler<AssignNumeroPedidoRequest, AssignNumeroPedidoResponse>
    {
        private readonly IPedidoRepository _repository;

        public AssignNumeroPedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<AssignNumeroPedidoResponse> Handle(AssignNumeroPedidoRequest request, CancellationToken cancellationToken)
        {
            if (!IsGuid(request.Id)) throw new BadRequestException("Id inválido.");

            var pedido = await _repository.GetPedidoById(request.Id, cancellationToken);

            pedido.SetNumeroPedido(request.NumeroDePedido);

            await _repository.UpdatePedido(pedido, cancellationToken);

            return new AssignNumeroPedidoResponse { Pedido = pedido.ToModel() };
        }

        public static bool IsGuid(Guid id)
        {
            return Guid.TryParse(id.ToString(), out _);
        }
    }
}