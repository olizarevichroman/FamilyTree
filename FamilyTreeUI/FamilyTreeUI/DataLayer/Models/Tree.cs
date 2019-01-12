using FamilyTreeLogic.DataLayer.Models;
using System.Collections.ObjectModel;

namespace FamilyTreeUI.DataLayer.Models
{
  public class Tree
  {
    public int Id { get; set; }

    public virtual ObservableCollection<Person> People { get; set; }
  }
}
