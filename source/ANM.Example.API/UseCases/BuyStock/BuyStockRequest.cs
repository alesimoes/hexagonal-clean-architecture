using System.ComponentModel.DataAnnotations;

namespace ANM.Example.API.UseCases.BuyStock
{
    public class BuyStockRequest
    {
        [Required]
        public int WalletId { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
