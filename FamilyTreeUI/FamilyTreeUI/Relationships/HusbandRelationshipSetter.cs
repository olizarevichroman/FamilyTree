using FamilyTreeLogic.DataLayer.Models;
using System.Linq;

namespace FamilyTreeUI.Relationships
{
  public class HusbandRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить мужа";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner)
    {
      return relationshipOwner.MainInfo.Sex != Sex.Male &&
             relationshipOwner.DependentPeople.
             FirstOrDefault(p => p.RelationshipType == RelationshipType.Husband) == null;
    }

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);
      dependencyPerson.RelationshipType = RelationshipType.Husband;
    }
  }
}
