using ANM.Example.Domain.ValueObjects.Exceptions;

namespace ANM.Example.Domain.ValueObjects
{
    public readonly struct Name
    {
        private readonly string _name;

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainFieldValidationException($"Name cannot be empty.");
            }
            this._name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
