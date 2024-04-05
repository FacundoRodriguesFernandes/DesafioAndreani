using Application.UseCase.AssignNumeroPedido;
using Application.UseCase.CreatePedido;
using Application.UseCase.GetPedidoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("pedido")]
        public async Task<ActionResult> CreatePedido([FromBody] PedidoModel pedido)
        {
            var response = _mediator.Send(new CreatePedidoRequest
            {
                CurrentAccount = pedido.CurrentAccount,
                InternalContractCode = pedido.InternalContractCode
            });

            //TODO: devolver el header

            return Created();
        }

        [HttpGet]
        [Route("pedido/{id}")]
        public async Task<ActionResult> GetPedidoById(Guid id)
        {
            var response = await _mediator.Send(new GetPedidoByIdRequest
            {
                Id = id
            });

            //TODO: devolver el header

            return Ok(response.Pedido);
        }

        [HttpPut]
        [Route("pedido/{id}")]
        public async Task<ActionResult> AssignNumeroPedido(Guid id, long numeroDePedido)
        {
            var response = await _mediator.Send(new AssignNumeroPedidoRequest
            {
                Id = id,
                NumeroDePedido = numeroDePedido
            });

            //TODO: devolver el header

            return Ok(response.Pedido);
        }
    }
}