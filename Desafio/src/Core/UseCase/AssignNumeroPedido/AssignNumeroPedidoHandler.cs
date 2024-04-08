using Core.Interfaces;
using Core.Mapping;
using Core.Model;
using MediatR;

namespace Core.UseCase.AssignNumeroPedido;

public struct AssignNumeroPedidoResponse
{
    public PedidoModel Pedido { get; set; }
}

public struct AssignNumeroPedidoRequest : IRequest<AssignNumeroPedidoResponse>
{
    public Guid Id { get; set; }
    public long NumeroDePedido { get; set; }
}

public class AssignNumeroPedidoHandler : IRequestHandler<AssignNumeroPedidoRequest, AssignNumeroPedidoResponse>
{
    private readonly IPedidoRepository _repository;

    public AssignNumeroPedidoHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AssignNumeroPedidoResponse> Handle(AssignNumeroPedidoRequest request, CancellationToken cancellationToken)
    {
        var pedido = await _repository.GetPedidoById(request.Id, cancellationToken);

        pedido.SetNumeroPedido(request.NumeroDePedido);

        await _repository.UpdatePedido(pedido, cancellationToken);

        return new AssignNumeroPedidoResponse { Pedido = pedido.ToModel() };
    }
}