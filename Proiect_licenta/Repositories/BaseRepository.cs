using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Interfaces;
using System.Linq;

namespace Disertatie_backend.Repositories
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity element)
        {
            _context.Add(element);
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            _context.Remove(_context.Find<TEntity>(id));
            _context.SaveChanges();
        }

        public TEntity[] Get()
        {
            return _context.Set<TEntity>().ToArray();
        }

        public TEntity Get(object id)
        {
            return _context.Find<TEntity>(id);
        }


        public void Update(TEntity element)
        {
            _context.Update(element);
            _context.SaveChanges();
        }
    }
}
