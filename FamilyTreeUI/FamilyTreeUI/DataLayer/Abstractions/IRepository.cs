using System.Collections.Generic;

namespace FamilyTreeUI.DataLayer.Abstractions
{
  public interface IRepository<TEntity> : IReadonlyRepository<TEntity> where TEntity : class
  {
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);
  }
}
