using FamilyTreeUI.DataLayer.Models;

namespace FamilyTreeLogic.DataLayer.Models
{
  public class Country : IEntity
  {
    public int Id { get; set; }

    public string Title { get; set; }
  }
}
