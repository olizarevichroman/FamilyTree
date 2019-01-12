using FamilyTreeUI.DataLayer.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FamilyTreeUI.Extensions
{
  public static class RepositoryExtensions
  {
    public static void LoadLocal<T>(this IReadonlyRepository<T> repository) where T : class
    {
      repository.Context.Set<T>().Load();
    }

    public static void LoadLocal<T>(this IReadonlyRepository<T> repository, Expression<Func<T, bool>> condition) where T : class
    {
      repository.Context.Set<T>().Where(condition).Load();
    }

    public static ObservableCollection<T> GetLocal<T>(this IReadonlyRepository<T> repository) where T : class
    {
      return repository.Context.Set<T>().Local;
    }

    public static ObservableCollection<T> GetLocal<T>(this IReadonlyRepository<T> repository, Expression<Func<T, bool>> condition) where T : class
    {
      return repository.Context.Set<T>().Local;
    }
  }
}
