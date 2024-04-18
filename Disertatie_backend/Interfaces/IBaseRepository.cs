using Microsoft.EntityFrameworkCore;

namespace Disertatie_backend.Interfaces
{
    public interface IBaseRepository<TEntity, TContext>
           where TEntity : class
           where TContext : DbContext
    {
        TEntity[] Get();
        TEntity Get(object id);
        void Add(TEntity element);
        void Update(TEntity element);
        void Delete(object id);
    }
}
