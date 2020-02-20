using ANM.Example.Domain.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace ANM.Example.Domain.ValueObjects
{
    public readonly struct Email
    {
        private readonly string _email;

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainFieldValidationException($" E-mail cannot be empty");
            }

            var regex = @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var match = Regex.Match(email, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                throw new DomainFieldValidationException($"Invalid e-mail address.");
            }

            this._email = email;
        }

        public override string ToString()
        {
            return _email;
        }
    }
}
