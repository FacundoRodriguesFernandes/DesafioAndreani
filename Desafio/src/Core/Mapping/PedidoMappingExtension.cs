using Core.Entities;
using Core.Model;

namespace Core.Mapping
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