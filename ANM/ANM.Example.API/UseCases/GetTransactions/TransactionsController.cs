using ANM.Example.Application.UseCases.GetTransactions;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ANM.Example.API.UseCases.GetTransactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly GetTransactionsPresenter _presenter;

        public TransactionsController(IMediator mediator,
            GetTransactionsPresenter presenter
           )
        {
            this._mediator = mediator;
            this._presenter = presenter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTransactionsResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery][Required] GetTransactionsRequest request)
        {
            var input = new GetTransactionsInput(request.WalletId, request.StartDate, request.EndDate);
            await _mediator.PublishAsync(input);
            return this._presenter.ViewModel;
        }
    }
}
