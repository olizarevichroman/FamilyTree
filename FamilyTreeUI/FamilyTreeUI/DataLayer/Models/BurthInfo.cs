using System;

namespace FamilyTreeLogic.DataLayer.Models
{
  public class BurthInfo
  {
    public int Id { get; set; }
    public DateTime? BurthDate { get; set; }

    public virtual LocationDetails BurthLocation { get; set; }

    public virtual Person Person { get; set; }
  }
}
