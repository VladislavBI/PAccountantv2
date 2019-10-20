namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Account
{
    public class AccountTransferDataItem
    {
        public decimal Amount { get; set; }

        public int IdAccountFrom { get; set; }

        public int IdAccountTo { get; set; }
    }
}
