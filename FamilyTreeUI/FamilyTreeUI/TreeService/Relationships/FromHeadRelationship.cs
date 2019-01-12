using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.Relationships;
using System.Collections.Generic;

namespace FamilyTreeUI.TreeService.Relationships
{
  public class FromHeadRelationship : IRelationship
  {
    private readonly string ownerToHeadRelationship = "Обратившийся";

    private Dictionary<RelationshipType, string> _relationsips;

    public FromHeadRelationship()
    {
      InitializeDictionary();
    }

    public string TryGetRelationship(Person newPerson)
    {
      string relationship = null;

      if (newPerson.RelationshipOwner.RelationshipToHead == ownerToHeadRelationship)
      {
       var isSuccessful = _relationsips.TryGetValue(newPerson.RelationshipType, out relationship);
      }

      return relationship;
    }

    private void InitializeDictionary()
    {
      _relationsips = new Dictionary<RelationshipType, string>()
      {
        {RelationshipType.Brother, "Брат" },
        {RelationshipType.Sister, "Сестра" },
        {RelationshipType.Mom, "Мама" },
        {RelationshipType.Dad, "Отец" },
        {RelationshipType.Husband, "Муж" },
        {RelationshipType.Wife, "Жена" },
        {RelationshipType.Son, "Сын" },
        {RelationshipType.Daughter, "Дочь" }
      };
    }
  }
}
