using Microsoft.EntityFrameworkCore;

namespace Proiect_licenta.Interfaces
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
