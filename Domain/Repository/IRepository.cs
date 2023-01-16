namespace Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
