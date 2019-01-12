using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Relationships
{
  public class SisterRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить сестру";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner) => true;

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);
      dependencyPerson.RelationshipType = RelationshipType.Sister;
    }
  }
}
