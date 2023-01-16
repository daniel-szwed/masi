using Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Added;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> result = await dbSet
                .Include("Elimination")
                .Include("Sequence")
                .ToListAsync();

            return result;
        }

        public void Remove(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.AttachRange(entities);
            context.Entry(entities).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            dbSet.AttachRange(entities);
            context.Entry(entities).State = EntityState.Modified;
        }
    }
}
