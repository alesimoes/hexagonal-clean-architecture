using ANM.Example.Application.UseCases.GetTransactions;
using Microsoft.AspNetCore.Mvc;

namespace ANM.Example.API.UseCases.GetTransactions
{
    public class GetTransactionsPresenter : IGetTransactionsOutput
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Ok(GetTransactionsOutput output)
        {
            ViewModel = new OkObjectResult(new GetTransactionsResponse(output.Transactions));
        }
    }
}
