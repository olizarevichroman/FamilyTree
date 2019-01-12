using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Relationships
{
  public class ChildRelationshipSetter : IRelationshipSetter
  {
    public string RelationName { get; set; } = "Добавить ребёнка";

    public bool IsRelationshipCanBeSetted(Person relationshipOwner) => true;

    public void SetRelationship(Person relationshipOwner, Person dependencyPerson)
    {
      relationshipOwner.DependentPeople.Add(dependencyPerson);

      dependencyPerson.RelationshipType = dependencyPerson.MainInfo.Sex == Sex.Female ? RelationshipType.Daughter : RelationshipType.Son;
    }
  }
}
