using ANM.Example.Application.UseCases.GetWallet;
using Microsoft.AspNetCore.Mvc;

namespace ANM.Example.API.UseCases.GetWallet
{
    public class GetWalletPresenter : IGetWalletOutput
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Ok(GetWalletOutput output)
        {
            ViewModel = new OkObjectResult(new GetWalletResponse(output.Stocks, output.Amount));
        }
    }
}
