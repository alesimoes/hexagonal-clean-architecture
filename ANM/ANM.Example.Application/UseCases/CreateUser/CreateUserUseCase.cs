using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Application.Abstractions.Services;
using ANM.Example.Domain.User.Services;
using ANM.Example.Domain.ValueObjects;
using ANM.Example.Domain.ValueObjects.Exceptions;
using System.Threading.Tasks;

namespace ANM.Example.Application.UseCases.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly ICreateUserOutput _outputPort;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserUseCase(
            ICreateUserOutput CreateUserOutput,
            IUserService userService,
            IUserRepository userRepository,
            IEventPublisher eventPublisher,
            IUnitOfWork unitOfWork)
        {
            this._outputPort = CreateUserOutput;
            this._userService = userService;
            this._userRepository = userRepository;
            this._eventPublisher = eventPublisher;
            this._unitOfWork = unitOfWork;
        }

        public async Task Execute(CreateUserInput input)
        {
            try
            {
                var user = this._userService.CreateUser(new Name(input.Name), new Email(input.Email));
                await this._userRepository.Add(user);
                await this._unitOfWork.Save();
                await this._eventPublisher.Publish(user.GetEvents());
                _outputPort.Ok(new CreateUserOutput(user));
            }
            catch (DomainFieldValidationException ex)
            {
                _outputPort.Error(ex.Message);
            }
        }
    }
}
