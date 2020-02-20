using System.ComponentModel.DataAnnotations;

namespace ANM.Example.API.UseCases.CreateUser
{
    public sealed class CreateUserRequest
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
