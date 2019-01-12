using FamilyTreeLogic.DataLayer;
using FamilyTreeLogic.DataLayer.Implementations;
using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.DataLayer.Abstractions;

namespace FamilyTreeUI.DataLayer.Implementations
{
  public class PersonRepository : Repository<Person>, IPersonRepository
  {
    public PersonRepository(ApplicationContext context) : base(context)
    {

    }
  }
}
