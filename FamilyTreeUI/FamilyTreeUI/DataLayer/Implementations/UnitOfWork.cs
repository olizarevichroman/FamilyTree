using FamilyTreeLogic.DataLayer.Abstractions;
using FamilyTreeUI.DataLayer.Abstractions;
using FamilyTreeUI.DataLayer.Implementations;
using System;

namespace FamilyTreeLogic.DataLayer.Implementations
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private readonly ApplicationContext _context;

    protected bool isDisposed = false;

    public UnitOfWork()
    {
      _context = new ApplicationContext();
      CountriesRepository = new CountriesRepository(_context);
      PersonRepository = new PersonRepository(_context);
      TreeRepository = new TreeRepository(_context);
    }
    public ICountriesRepository CountriesRepository { get; set; }
    public IPersonRepository PersonRepository { get; set; }

    public ITreeRepository TreeRepository { get; set; }

    public int Complete()
    {
      return _context.SaveChanges();
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (isDisposed)
      {
        return;
      }

      if (disposing)
      {
        _context.Dispose();
      }

      isDisposed = true;
    }

    ~UnitOfWork()
    {
      Dispose(false);
    }
  }
}
