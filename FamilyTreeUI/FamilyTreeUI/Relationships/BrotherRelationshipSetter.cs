using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Relationships
{
  public class BrotherRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить брата";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner) => true;

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);

      dependencyPerson.RelationshipType = RelationshipType.Brother;
    }
  }
}
