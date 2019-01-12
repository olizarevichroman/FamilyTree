using FamilyTreeUI.DataLayer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeLogic.DataLayer.Models
{
  public class AdditionalInfo
  {
    public int Id { get; set; }

    public string Nationality { get; set; }

    public string SocialStatus { get; set; }

    public virtual ObservableCollection<Profession> Professions { get; set; }
    public string HowInformationWasObtained { get; set; }

    public string LifeDetails { get; set; }

    public virtual Person Person { get; set; }
  }
}
