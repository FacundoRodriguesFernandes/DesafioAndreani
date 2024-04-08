using Confluent.Kafka;
using Core.UseCase.AssignNumeroPedido;
using Core.UseCase.CreatePedido;
using Core.UseCase.GetPedidoById;
using Kafka.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.SecurityTokenService;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPedidoConsumerService _consumer;
        private readonly IPedidoProducerService _producer;

        public PedidoController(IMediator mediator, IPedidoConsumerService consumer, IPedidoProducerService producer)
        {
            _mediator = mediator;
            _consumer = consumer;
            _producer = producer;
        }

        [HttpPost]
        [Route("pedido")]
        public async Task<ActionResult> CreatePedido([FromBody] PedidoModel pedido)
        {
            //var response = await _mediator.Send(new CreatePedidoRequest
            //{
            //    CurrentAccount = Convert.ToInt64(pedido.CurrentAccount),
            //    InternalContractCode = Convert.ToInt64(pedido.InternalContractCode)
            //});

            //HttpContext.Response.Headers.Add("Location", "attribute response");
            //HttpContext.Response.Headers.Add("x-my-custom-header", "attribute response");

            //return Created(string.Empty, response);

            var topic = "PedidoCreado";
            await _producer.ProduceAsync(topic, "creado");

            return Created();
        }

        [HttpGet]
        [Route("pedido/{id}")]
        public async Task<ActionResult> GetPedidoById(Guid id)
        {
            if (!IsGuid(id)) throw new BadRequestException("Id inválido.");

            var response = await _mediator.Send(new GetPedidoByIdRequest
            {
                Id = id
            });

            return Ok(response.Pedido);
        }

        [HttpPut]
        [Route("pedido/{id}")]
        public async Task<ActionResult> AssignNumeroPedido(Guid id, long numeroDePedido)
        {
            if (!IsGuid(id)) throw new BadRequestException("Id inválido.");

            var response = await _mediator.Send(new AssignNumeroPedidoRequest
            {
                Id = id,
                NumeroDePedido = numeroDePedido
            });

            return Ok(response.Pedido);
        }

        public static bool IsGuid(Guid id) => Guid.TryParse(id.ToString(), out _);
    }
}