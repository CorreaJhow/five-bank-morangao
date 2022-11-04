using Five.Bank.Domain.Contracts.v1;

namespace Five.Bank.Domain.Entities.v1;
public sealed class Account : IEntity
{
    public Account(Guid custumerId) : this(Guid.NewGuid(), new(), custumerId, false) { }

    public Account(Guid id, List<Transaction> transactions, Guid custumerId, bool isClosed)
    {
        Id = id;
        Transactions = transactions;
        CustumerId = custumerId;
        IsClosed = isClosed;
    }

    public Guid Id { get; init; }
    public List<Transaction> Transactions { get; init; }
    public Guid CustumerId { get; private set; }
    public bool IsClosed { get; private set; }

    public void Deposit(Credit credit)
    {
        Transactions.Add(credit);
    }
    public void WithDraw(Debit debit)
    {
        //Mesma coisa, porém sem função
        //var amount = 0M;
        //foreach (var transaction in Transactions)
        //{
        //    if (transaction is Debit)
        //        amount -= transaction.Amount;
        //    else
        //        amount += transaction.Amount;
        //}
        if (GetCurrentBalance() > debit.Amount) Transactions.Add(debit);
        throw new Exception($"A conta nao possui saldo para saque");
    }

    private decimal GetCurrentBalance()
    {
        return Transactions.Sum(transaction =>
        {
            if (transaction is Debit) return transaction.Amount * -1;
            return transaction.Amount;
        });
    }

    public void Open(Guid costumerId, Credit credit)
    {
        CustumerId = costumerId;
        Deposit(credit);
        IsClosed = false;
    }
    public void Close()
    {
        if (GetCurrentBalance() == 0)
        {
            IsClosed = true;
            return;
        }
        throw new Exception("A conta possui saldo a retirar!!");
    }
}

