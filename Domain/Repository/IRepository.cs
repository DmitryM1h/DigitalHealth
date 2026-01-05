using Core.Contracts;

namespace DigitalHealth.Domain.Repository
{
    public interface IRepository<TEntity, TId> where TEntity : AggregateRoot<TId>
    {
        Task<TEntity> GetById(TId id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    
    }
}
