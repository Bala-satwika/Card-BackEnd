using System.ComponentModel.DataAnnotations;

namespace apiAndAsp.models
{
    public class card
    {
        [Key]
        public Guid Id { get; set; }
        public string cardHolderName { get; set; }
        public string cardNumber { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
        public string cvc { get; set; }

    }
}
