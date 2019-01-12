using FamilyTreeLogic.DataLayer.Models;
using System.Linq;

namespace FamilyTreeUI.Relationships
{
  public class WifeRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить жену";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner)
    {
      return relationshipOwner.MainInfo.Sex != Sex.Female &&
             relationshipOwner.DependentPeople.
             FirstOrDefault(p => p.RelationshipType == RelationshipType.Wife) == null;
    }

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);
      dependencyPerson.RelationshipType = RelationshipType.Wife;
    }
  }
}
