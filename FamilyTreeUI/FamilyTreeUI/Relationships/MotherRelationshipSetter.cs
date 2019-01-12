using FamilyTreeLogic.DataLayer.Models;
using System.Linq;

namespace FamilyTreeUI.Relationships
{
  public class MotherRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить маму";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner)
    {
      return relationshipOwner.DependentPeople.
       FirstOrDefault(p => p.RelationshipType == RelationshipType.Mom) == null;
    }

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);
      dependencyPerson.RelationshipType = RelationshipType.Mom;
    }
  }
}
