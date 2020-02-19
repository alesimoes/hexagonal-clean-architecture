using System.ComponentModel.DataAnnotations;

namespace ANM.Example.API.UseCases.CreateUser
{
    public sealed class CreateUserResponse
    {
        public CreateUserResponse(int id, string name, int walletId)
        {
            this.Id = id;
            this.Name = name;
            this.WalletId = walletId;
        }

        public int Id { get; }

        public string Name { get; }
        public int WalletId { get; }
    }
}
