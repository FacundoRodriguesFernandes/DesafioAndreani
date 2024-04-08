namespace Kafka.Models
{
    internal class CreatePedidoRequest
    {
        public Guid Id { get; set; }
        public long? NumeroDePedido { get; set; }
        public Guid CicloDelPedido { get; set; }
        public long CodigoDeContratoInterno { get; set; }
        public int EstadoDelPedido { get; set; }
        public long CuentaCorriente { get; set; }
        public DateTime Cuando { get; set; }
    }
}