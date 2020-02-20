using ANM.Example.Application.UseCases.SellStock;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ANM.Example.API.UseCases.SellStock
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SellStockPresenter _sellStockPresenter;

        public StockController(IMediator mediator,
            SellStockPresenter sellStockPresenter
           )
        {
            this._mediator = mediator;
            this._sellStockPresenter = sellStockPresenter;
        }

        [HttpPatch("Sell")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SellStockResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] [Required] SellStockRequest request)
        {

            var input = new SellStockInput(request.WalletId, request.Ticker, request.Quantity, request.Amount);
            await _mediator.PublishAsync(input);
            return this._sellStockPresenter.ViewModel;
        }
    }
}
