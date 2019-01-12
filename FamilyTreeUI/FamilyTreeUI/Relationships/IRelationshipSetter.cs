using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Relationships
{
  public interface IRelationshipSetter
  {
    bool IsRelationshipCanBeSetted(Person relationshipOwner);
    string RelationName { get; set; }
    void SetRelationship(Person relationshipOwner, Person dependencyPerson);
  }
}