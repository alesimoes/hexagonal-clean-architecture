using ANM.Example.Application.UseCases.BuyStock;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ANM.Example.API.UseCases.BuyStock
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly BuyStockPresenter _buyStockPresenter;

        public StockController(IMediator mediator,
            BuyStockPresenter buyStockPresenter
           )
        {
            this._mediator = mediator;
            this._buyStockPresenter = buyStockPresenter;
        }

        [HttpPatch("Buy")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyStockResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] [Required] BuyStockRequest request)
        {

            var input = new BuyStockInput(request.WalletId, request.Ticker, request.Quantity, request.Amount);
            await _mediator.PublishAsync(input);
            return this._buyStockPresenter.ViewModel;
        }
    }
}
