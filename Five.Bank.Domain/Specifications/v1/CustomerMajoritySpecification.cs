using System;
using System.Data;

namespace Five.Bank.Domain.Specifications.v1;
public class CustomerMajoritySpecification
{
    private readonly DateOnly _birhtday;
    public CustomerMajoritySpecification(DateOnly birhtday)
    {
        _birhtday = birhtday;
    }
    public bool IsSatisfied() => DateTime.Now.Year - _birhtday.Year >= 18;
}
