using ANM.Example.Application.UseCases.GetWallet;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ANM.Example.API.UseCases.GetWallet
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly GetWalletPresenter _presenter;

        public WalletController(IMediator mediator,
            GetWalletPresenter presenter
           )
        {
            this._mediator = mediator;
            this._presenter = presenter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetWalletResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery][Required] GetWalletRequest request)
        {
            var input = new GetWalletInput(request.WalletId);
            await _mediator.PublishAsync(input);
            return this._presenter.ViewModel;
        }
    }
}