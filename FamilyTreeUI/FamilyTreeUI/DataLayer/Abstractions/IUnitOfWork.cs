using FamilyTreeUI.DataLayer.Abstractions;
using System;

namespace FamilyTreeLogic.DataLayer.Abstractions
{
  public interface IUnitOfWork : IDisposable
  {
    ICountriesRepository CountriesRepository { get; set; }

    IPersonRepository PersonRepository { get; set; }

    ITreeRepository TreeRepository { get; set; }

    int Complete();
  }
}
