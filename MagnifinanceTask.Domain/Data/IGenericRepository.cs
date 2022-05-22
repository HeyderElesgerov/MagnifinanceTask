using System.Linq.Expressions;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Domain.Data;

public interface IGenericRepository<TEntity, in TKey> where TEntity : Entity<TKey>
{
    void Add(TEntity entity);

    void Update(TEntity entity);
    
    void Delete(TEntity entity);
    
    TEntity? GetById(TKey id);
    
    bool Exists(TKey id);
    
    TEntity? GetByIdIncluding(TKey id, params Expression<Func<TEntity, object>>[] includes);
    
    IEnumerable<TEntity> GetAll();

    IEnumerable<TEntity> GetAllIncludingExpression(Expression<Func<TEntity, object>>[] includes);
    
    IEnumerable<TEntity> GetAllIncluding(string includes);

    IEnumerable<TEntity> GetWhere(Func<TEntity, bool> filter);
    
    IEnumerable<TEntity> GetWhereIncluding(Func<TEntity, bool> filter, params Expression<Func<TEntity, object>>[] includes);
}