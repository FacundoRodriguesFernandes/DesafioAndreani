namespace Domain.Entities
{
    public class Pedido
    {
        public int CurrentAccount { get; set; }
        public int InternalContractCode { get; set; }

        public Pedido(int currentAccount, int internalContractCode)
        {
            CurrentAccount = currentAccount;
            InternalContractCode = internalContractCode;
        }
    }
}
