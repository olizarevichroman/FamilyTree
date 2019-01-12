using System;

namespace FamilyTreeLogic.DataLayer.Models
{
  public class Residence
  {
    public int Id { get; set; }
    public int LocationId { get; set; }

    public virtual LocationDetails Location { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
  }
}
