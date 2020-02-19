using System.ComponentModel.DataAnnotations;

namespace ANM.Example.API.UseCases.SellStock
{
    public class SellStockRequest
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
