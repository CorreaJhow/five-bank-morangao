using Five.Bank.Domain.ValuesObjects.v1;

namespace Five.Bank.Api.Models.v1;
public class CustomerInputModel
{
    public string? Name { get; init; }
    public string? Document { get; init; }
    public DateTime Birthday { get; init; }
    public Address? Address { get; init; }
}
