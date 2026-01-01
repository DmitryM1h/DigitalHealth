using Core.Contracts;

namespace DigitalHealth.Domain.Repository
{
    public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot<TId>
    {
        Task<TEntity> GetById(TId id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        // Potentially add methods for specification-based queries
        // e.g., IEnumerable<TEntity> Find(ISpecification<TEntity> specification);
    }
}
