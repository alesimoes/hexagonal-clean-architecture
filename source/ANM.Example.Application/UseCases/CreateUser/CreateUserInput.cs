using ANM.Core.Application.Abstractions.UseCase;
using ANM.Example.Application.Abstractions.Exceptions;

namespace ANM.Example.Application.UseCases.CreateUser
{
    public sealed class CreateUserInput : IUseCaseInput
    {
        public CreateUserInput(string name, string email)
        {
            this.Name = name;
            this.Email = email;
            this.Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new ApplicationFieldValidationException($"Name is required.");
            }
            if (string.IsNullOrWhiteSpace(this.Email))
            {
                throw new ApplicationFieldValidationException($"E-mail is required.");
            }
        }

        public string Name { get; }

        public string Email { get; }
    }
}
