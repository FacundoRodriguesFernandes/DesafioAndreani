using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.IdentityModel.SecurityTokenService;

namespace Core.UseCase.CreatePedido
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoRequest, CreatePedidoResponse>
    {
        private readonly IPedidoRepository _repository;

        public CreatePedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public Task<CreatePedidoResponse> Handle(CreatePedidoRequest request, CancellationToken cancellationToken)
        {
            if (!IsValid(request)) throw new BadRequestException("Valores inválidos");

            var pedido = new Pedido(request.CurrentAccount, request.InternalContractCode);

            _repository.CreatePedido(pedido, cancellationToken);

            return Task.FromResult(new CreatePedidoResponse());
        }

        public static bool IsValid(CreatePedidoRequest request) => request.CurrentAccount >= 0 || request.InternalContractCode >= 0;
    }
}