using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.DataLayer.Models
{
  public class Profession
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public AdditionalInfo AdditionalInfo { get; set; }

    public int AdditionalInfoId { get; set; }
  }
}
