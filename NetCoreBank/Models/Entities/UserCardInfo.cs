namespace NetCoreBank.Models.Entities
{
    public class UserCardInfo : BaseEntity
    {
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public decimal CardLimit { get; set; } //Bir ayda bu kart maksimum ne kadar harcama yapabilir
        public decimal Balance { get; set; }


    }
}
