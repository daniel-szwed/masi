namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        Task<ITransaction> BeginTransactionAsync();
        IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;
        Task<int> SaveChangesAsync();
    }
}
