using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.TreeService
{
  public interface IRelarionshipResolver
  {
    void Resolve(Person newPerson);
  }
}
