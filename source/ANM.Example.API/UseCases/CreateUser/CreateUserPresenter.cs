using ANM.Example.Application.UseCases.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace ANM.Example.API.UseCases.CreateUser
{
    public sealed class CreateUserPresenter : ICreateUserOutput
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {

            ViewModel = new BadRequestObjectResult(message);
        }

        public void Ok(CreateUserOutput output)
        {
            ViewModel = new OkObjectResult(new CreateUserResponse(output.Id.Value, output.Name.ToString(), output.WalletId));
        }
    }
}
