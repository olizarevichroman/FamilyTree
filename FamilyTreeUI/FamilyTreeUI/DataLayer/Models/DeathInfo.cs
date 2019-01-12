using FamilyTreeUI.DataLayer.Models;
using System;

namespace FamilyTreeLogic.DataLayer.Models
{
  public class DeathInfo : IEntity
  {
    public int Id { get; set; }
    public DateTime? DeathDate { get; set; }

    public virtual LocationDetails DeathLocation { get; set; }

    public bool IsApproximateDate { get; set; }

    public virtual Person Person { get; set; }
  }
}
