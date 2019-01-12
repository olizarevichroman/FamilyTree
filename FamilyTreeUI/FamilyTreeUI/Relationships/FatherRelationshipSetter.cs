using FamilyTreeLogic.DataLayer.Models;
using System.Linq;

namespace FamilyTreeUI.Relationships
{
  public class FatherRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить отца";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner)
    {
      return relationshipOwner.DependentPeople.FirstOrDefault(p => p.RelationshipType == RelationshipType.Dad) == null;
    }

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);
      dependencyPerson.RelationshipType = RelationshipType.Dad;
    }
  }
}
