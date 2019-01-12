using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.TreeService.Relationships;

namespace FamilyTreeUI.TreeService
{
  public class RelationshipResolver : IRelarionshipResolver
  {
    private static IEnumerable<IRelationship> _relationships;

    static RelationshipResolver()
    {
      _relationships = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.GetInterfaces().Contains(typeof(IRelationship)))
        .Select(t => Activator.CreateInstance(t) as IRelationship);
    }
    public void Resolve(Person newPerson)
    {
      string relationshipValue;

      foreach (var relationsip in _relationships)
      {
        relationshipValue = relationsip.TryGetRelationship(newPerson);

        if (relationshipValue != null)
        {
          newPerson.RelationshipToHead = relationshipValue;
          return;
        }
      }

      newPerson.RelationshipToHead = "Связь не установлена";
    }
  }
}
