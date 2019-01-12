using FamilyTreeLogic.DataLayer.Abstractions;
using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.DataLayer.Implementations;

namespace FamilyTreeLogic.DataLayer.Implementations
{
  public class CountriesRepository : ReadonlyRepository<Country>, ICountriesRepository
  {
    public CountriesRepository(ApplicationContext context) : base(context) { }
  }
}
