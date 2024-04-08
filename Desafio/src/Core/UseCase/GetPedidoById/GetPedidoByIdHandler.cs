using Core.Interfaces;
using Core.Mapping;
using Core.Model;
using MediatR;

namespace Core.UseCase.GetPedidoById;

public struct GetPedidoByIdResponse
{
    public PedidoModel Pedido { get; set; }
}

public struct GetPedidoByIdRequest : IRequest<GetPedidoByIdResponse>
{
    public Guid Id { get; set; }
}

public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdRequest, GetPedidoByIdResponse>
{
    private readonly IPedidoRepository _repository;

    public GetPedidoByIdHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetPedidoByIdResponse> Handle(GetPedidoByIdRequest request, CancellationToken cancellationToken)
    {
        var pedido = await _repository.GetPedidoById(request.Id, cancellationToken);

        if (pedido == null) throw new NullReferenceException($"El pedido con Id {request.Id} no existe.");

        return new GetPedidoByIdResponse { Pedido = pedido.ToModel() };
    }
}