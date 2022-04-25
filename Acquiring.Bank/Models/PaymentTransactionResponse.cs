namespace Acquiring.Bank.Models
{
    public class PaymentTransactionResponse
    {
        public string TransactionId { get; set; }

        public PaymentTransactionStatus Status { get; set; }
    }
}
