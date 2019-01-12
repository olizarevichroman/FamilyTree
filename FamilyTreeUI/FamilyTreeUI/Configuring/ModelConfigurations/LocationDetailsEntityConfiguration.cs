using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class LocationDetailsEntityConfiguration : BaseEntityConfiguration<LocationDetails>
  {
    protected override void Configure()
    {
      HasKey(l => l.Id);

      HasOptional(l => l.Country);
        
    }
  }
}
