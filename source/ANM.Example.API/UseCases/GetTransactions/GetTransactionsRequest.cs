using System;
using System.ComponentModel.DataAnnotations;

namespace ANM.Example.API.UseCases.GetTransactions
{
    public class GetTransactionsRequest
    {
        [Required]
        public int WalletId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
