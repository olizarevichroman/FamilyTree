using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace FamilyTreeUI.DataLayer.Abstractions
{
  public interface IReadonlyRepository<TEntity> where TEntity : class
  {
    DbContext Context { get; }
    IEnumerable<TEntity> GetAll();

    TEntity Get(int id);

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
  }
}
