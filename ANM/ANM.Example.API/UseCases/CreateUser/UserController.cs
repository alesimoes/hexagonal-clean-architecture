using ANM.Example.Application.UseCases.CreateUser;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ANM.Example.API.UseCases.CreateUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CreateUserPresenter _CreateUserPresenter;


        public UserController(IMediator mediator,
            CreateUserPresenter CreateUserPresenter
           )
        {
            this._mediator = mediator;
            this._CreateUserPresenter = CreateUserPresenter;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] [Required] CreateUserRequest request)
        {

            var input = new CreateUserInput(request.Name, request.Email);
            await _mediator.PublishAsync(input);
            return this._CreateUserPresenter.ViewModel;
        }
    }
}