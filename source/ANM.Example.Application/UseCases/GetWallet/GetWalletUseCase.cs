using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Domain.Wallets;
using System.Threading.Tasks;

namespace ANM.Example.Application.UseCases.GetWallet
{
    public class GetWalletUseCase : IGetWalletUseCase
    {
        private readonly IGetWalletOutput _output;
        private readonly IWalletRepository _repository;

        public GetWalletUseCase(IGetWalletOutput output, IWalletRepository walletRepository)
        {
            this._output = output;
            this._repository = walletRepository;
        }

        public async Task Execute(GetWalletInput input)
        {
            var wallet = await _repository.GetWalletBy(input.WalletId);

            BuildOutput(wallet);
        }

        private void BuildOutput(Wallet wallet)
        {
            if (wallet == null)
            {
                this._output.Error("Wallet not found");
            }
            else
            {
                this._output.Ok(new GetWalletOutput(wallet));
            }
        }
    }
}
