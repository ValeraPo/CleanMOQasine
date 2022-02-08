namespace CleanMOQasine.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual Order? Order { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsDeleted { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Payment)
                return false;
            Payment payment = (Payment)obj;
            if (Id != payment.Id
                || Amount != payment.Amount
                || PaymentDate != payment.PaymentDate
                || IsDeleted != payment.IsDeleted)
                return false;
            return true;
        }

        public override string ToString()
        {
            return $"{Id} {Amount} {PaymentDate} {IsDeleted}";
        }
    }
}
