namespace WebApi.Models
{
    public class PedidoModel
    {
        [IsNumeric]
        public long CurrentAccount { get; set; }

        [IsNumeric]
        public long InternalContractCode { get; set; }
    }
}