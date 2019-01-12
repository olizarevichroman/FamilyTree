using FamilyTreeLogic.DataLayer.Models;
using System.Collections.Generic;

namespace FamilyTreeUI.Relationships
{
  public interface IRelationshipProvider
  {
    IEnumerable<IRelationshipSetter> GetRelationships(Person person);
  }
}
