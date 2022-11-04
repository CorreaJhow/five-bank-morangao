using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Specifications.v1;
using Five.Bank.Domain.ValuesObjects.v1;

namespace Five.Bank.Domain.Entities.v1;
public sealed class Customer : IEntity
{
    public Customer(string name, string document, DateOnly birthday, Address? address)
        :this(Guid.NewGuid(), name, document, birthday, address) { }
    public Customer(Guid id, string name, string document, DateOnly birthday, Address? address)
    {
        Id = id;
        Name = name;
        Document = document;
        Birthday = birthday;
        Address = address;
    }
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Document { get; init; }
    public DateOnly Birthday { get; init; }
    public Address? Address { get; init; }

    public bool Validate()
    {
        var documentoSpecification = new DocumentAlgorithmSpecification(Document);
        var birthdaySpecification = new CustomerMajoritySpecification(Birthday);
        return documentoSpecification.IsSatisfied() && birthdaySpecification.IsSatisfied();
    }
}

