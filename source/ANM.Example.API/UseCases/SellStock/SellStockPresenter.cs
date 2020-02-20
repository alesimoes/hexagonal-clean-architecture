using ANM.Example.Application.UseCases.SellStock;
using Microsoft.AspNetCore.Mvc;

namespace ANM.Example.API.UseCases.SellStock
{
    public class SellStockPresenter : ISellStockOutput
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Ok(SellStockOutput output)
        {
            ViewModel = new OkObjectResult(new SellStockResponse(output.Id, output.Ticker, output.Quantity, output.Amount));
        }
    }
}
