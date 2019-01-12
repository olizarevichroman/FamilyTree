using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.DataLayer.Abstractions;

namespace FamilyTreeLogic.DataLayer.Abstractions
{
  public interface ICountriesRepository : IReadonlyRepository<Country>
  {
  }
}
