using System.Linq.Expressions;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using MagnifinanceTask.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace MagnifinanceTask.Infrastructure.Data;

public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : Entity<TKey> 
{
    protected readonly TaskDbContext _context;

    public GenericRepository(TaskDbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public TEntity? GetById(TKey id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public bool Exists(TKey id)
    {
        return _context.Set<TEntity>().Find(id) != null;
    }

    public TEntity? GetByIdIncluding(TKey id, params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = _context.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }
        }
        
        return entities.FirstOrDefault(e => e.Id.Equals(id));
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAllIncludingExpression(Expression<Func<TEntity, object>>[] includes)
    {
        var entities = _context.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }
        }

        return entities;
    }

    public IEnumerable<TEntity> GetAllIncluding(string includes)
    {
        return _context.Set<TEntity>().Include(includes);
    }

    public IEnumerable<TEntity> GetWhere(Func<TEntity, bool> filter)
    { 
        return _context.Set<TEntity>().Where(filter);
    }

    public IEnumerable<TEntity> GetWhereIncluding(Func<TEntity, bool> filter, params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = _context.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            foreach (Expression<Func<TEntity,object>> expression in includes)
            {
                entities = entities.Include(expression);
            }
        }

        return entities.Where(filter);
    }
}