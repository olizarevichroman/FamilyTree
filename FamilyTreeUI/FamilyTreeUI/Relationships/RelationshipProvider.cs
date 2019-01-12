using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Relationships
{
  public class RelationshipProvider : IRelationshipProvider
  {
    private static IEnumerable<IRelationshipSetter> _allRelationshipSetters;
    public RelationshipProvider()
    {
      if (_allRelationshipSetters == null)
      {
        _allRelationshipSetters = FindSetters();
      }
    }

    private IEnumerable<IRelationshipSetter> FindSetters()
    {
      return Assembly.GetExecutingAssembly()
                      .GetTypes()
                      .Where(t => t.GetInterfaces().Contains(typeof(IRelationshipSetter)))
                      .Select(t => Activator.CreateInstance(t) as IRelationshipSetter);
    }
    public IEnumerable<IRelationshipSetter> GetRelationships(Person person)
    {
      return _allRelationshipSetters.Where(s => s.IsRelationshipCanBeSetted(person));
    }
  }
}
