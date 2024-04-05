namespace Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public long? NumeroDePedido { get; set; }
        public Guid CicloDelPedido { get; set; }
        public long CodigoDeContratoInterno { get; set; }
        public EstadoDePedido EstadoDelPedido { get; set; }
        public long CuentaCorriente { get; set; }
        public DateTime Cuando { get; set; }

        public Pedido()
        {
        }

        public Pedido(long currentAccount, long internalContractCode)
        {
            Id = Guid.NewGuid(); ;
            NumeroDePedido = null;
            CicloDelPedido = Id;
            CodigoDeContratoInterno = internalContractCode;
            EstadoDelPedido = EstadoDePedido.Creado;
            CuentaCorriente = currentAccount;
            Cuando = DateTime.Now;
        }

        public void SetNumeroPedido(long numeroDePedido)
        {
            NumeroDePedido = numeroDePedido;
        }
    }
}