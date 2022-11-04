using System.ComponentModel;
using Five.Bank.Domain.Specifications.v1;

namespace Five.Bank.Domain.Contracts.v1;
public interface IRepository<TEntity> where TEntity : IEntity
{
    Task AddAsync(TEntity obj);
    Task <TEntity> GetByIdAsync(Guid id);
}

