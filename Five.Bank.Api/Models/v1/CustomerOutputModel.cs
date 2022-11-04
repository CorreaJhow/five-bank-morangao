using Five.Bank.Domain.ValuesObjects.v1;

namespace Five.Bank.Api.Models.v1;
public class CustomerOutputModel
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Document { get; init; }
    public DateOnly Birthday { get; init; }
    public Address? Address { get; init; }
}
