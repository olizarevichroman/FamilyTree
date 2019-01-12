namespace FamilyTreeLogic.DataLayer.Models
{
  public class LocationDetails
  {
    public int Id { get; set; }

    public virtual Country Country { get; set; }

    public virtual string City { get; set; }

    public string Street { get; set; }

    public string HouseNumber { get; set; }

    public int? FlatNumber { get; set; }
  }

}
