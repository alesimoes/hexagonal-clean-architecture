using ANM.Core.Domain.Abstractions.Events;
using ANM.Example.Application.Abstractions.Repositories;
using ANM.Example.Application.Abstractions.Services;
using ANM.Example.Domain.Wallets;
using ANM.Example.Domain.Wallets.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ANM.Example.Application.UseCases.SellStock
{
    public class SellStockUseCase : ISellStockUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISellStockOutput _output;
        private readonly IWalletService _walletService;
        private readonly IWalletRepository _walletRepository;
        private readonly IEventPublisher _eventPublisher;

        public SellStockUseCase(IUnitOfWork unitOfWork,
            ISellStockOutput output,
            IWalletService walletService,
            IWalletRepository walletRepository,
            IEventPublisher eventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._output = output;
            this._walletService = walletService;
            this._walletRepository = walletRepository;
            this._eventPublisher = eventPublisher;
        }
        public async Task Execute(SellStockInput input)
        {
            var wallet = await this._walletRepository.GetWalletBy(input.WalletId);
            if (wallet == null)
            {
                this._output.Error("Wallet not found");
                return;
            }
            this._walletService.SellStock(wallet, input.Ticker, input.Quantity, input.Amount);
            await this._unitOfWork.Save();
            await this._eventPublisher.Publish(wallet.GetEvents());
            BuildOutputPort(input, wallet);

        }

        private void BuildOutputPort(SellStockInput input, Wallet wallet)
        {
            var stock = wallet.Stocks.FirstOrDefault(s => s.Ticker == input.Ticker);
            this._output.Ok(new SellStockOutput(stock));
        }
    }
}
