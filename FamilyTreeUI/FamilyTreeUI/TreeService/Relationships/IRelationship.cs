using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.TreeService.Relationships
{
  public interface IRelationship
  {
    string TryGetRelationship(Person newPerson);
  }
}
