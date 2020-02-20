using ANM.Example.Application.UseCases.BuyStock;
using Microsoft.AspNetCore.Mvc;

namespace ANM.Example.API.UseCases.BuyStock
{
    public class BuyStockPresenter : IBuyStockOutput
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Ok(BuyStockOutput output)
        {
            ViewModel = new OkObjectResult(new BuyStockResponse(output.Id, output.Ticker, output.Quantity, output.Amount));
        }
    }
}
