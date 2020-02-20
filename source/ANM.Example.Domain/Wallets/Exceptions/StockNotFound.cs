using ANM.Core.Domain.Abstractions.Exceptions;

namespace ANM.Example.Domain.Wallets.Exceptions
{
    public class StockNotFound : DomainException
    {
        public StockNotFound(string businessMessage) : base(businessMessage)
        {
        }
    }
}
