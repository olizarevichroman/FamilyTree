using FamilyTreeUI.DataLayer.Abstractions;
using FamilyTreeUI.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FamilyTreeUI.DataLayer.Implementations
{
  public class ReadonlyRepository<TEntity> : IReadonlyRepository<TEntity> where TEntity : class
  {
    public DbContext Context { get; }
    public ReadonlyRepository(DbContext context)
    {
      Context = context;
    }
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
      return Context.Set<TEntity>().Where(predicate);
    }

    public TEntity Get(int index)
    {
      return Context.Set<TEntity>().Find(index);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return Context.Set<TEntity>();
    }
  }
}
