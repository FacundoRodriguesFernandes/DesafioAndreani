using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Core.UseCase.CreatePedido;

public struct CreatePedidoRequest : IRequest<Unit>
{
    public long CurrentAccount { get; set; }
    public long InternalContractCode { get; set; }
}

public class CreatePedidoHandler : IRequestHandler<CreatePedidoRequest, Unit>
{
    private readonly IPedidoRepository _repository;

    public CreatePedidoHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreatePedidoRequest request, CancellationToken cancellationToken)
    {
        var pedido = new Pedido(request.CurrentAccount, request.InternalContractCode);

        await _repository.CreatePedido(pedido, cancellationToken);

        return Unit.Value;
    }
}