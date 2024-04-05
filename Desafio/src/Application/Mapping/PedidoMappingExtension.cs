using Application.Model;
using Domain.Entities;

namespace Application.Mapping
{
    public static class PedidoMappingExtension
    {
        public static PedidoModel ToModel(this Pedido entity)
        {
            var model = new PedidoModel
            {
                Id = entity.Id,
                CicloDelPedido = entity.CicloDelPedido,
                CodigoDeContratoInterno = entity.CodigoDeContratoInterno,
                Cuando = entity.Cuando,
                CuentaCorriente = entity.CuentaCorriente,
                EstadoDelPedido = entity.EstadoDelPedido,
                NumeroDePedido = entity.NumeroDePedido
            };

            return model;
        }
    }
}