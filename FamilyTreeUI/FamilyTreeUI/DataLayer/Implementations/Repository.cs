using FamilyTreeUI.DataLayer.Abstractions;
using FamilyTreeUI.DataLayer.Implementations;
using System.Collections.Generic;
using System.Data.Entity;

namespace FamilyTreeLogic.DataLayer.Implementations
{
  public class Repository<TEntity> : ReadonlyRepository<TEntity>, IRepository<TEntity> where TEntity : class
  {
    public Repository(DbContext context) : base(context)
    {

    }
    public void Add(TEntity entity)
    {
      Context.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
      Context.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
      Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
      Context.Set<TEntity>().RemoveRange(entities);
    }
  }
}
