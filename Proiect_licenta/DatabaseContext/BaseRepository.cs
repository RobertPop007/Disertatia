using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Interfaces;
using System.Linq;

namespace Proiect_licenta.DatabaseContext;

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
        _context.Remove(this._context.Find<TEntity>(id));
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
