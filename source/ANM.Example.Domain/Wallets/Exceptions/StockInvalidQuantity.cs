using ANM.Core.Domain.Abstractions.Exceptions;

namespace ANM.Example.Domain.Wallets.Exceptions
{
    public class StockException : DomainException
    {
        public StockException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
