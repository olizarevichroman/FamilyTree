namespace FamilyTreeLogic.DataLayer.Models
{
  public class Education
  {
    public int Id { get; set; }
    public virtual Country Country { get; set; }

    public string City { get; set; }

    public string University { get; set; }

    public virtual Person Person { get; set; }

    public int PersonId { get; set; }
  }
}
