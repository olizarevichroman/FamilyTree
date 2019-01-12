using FamilyTreeLogic.DataLayer.Models;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class DeathInfoEntityConfiguration : BaseEntityConfiguration<DeathInfo>
  {
    protected override void Configure()
    {
      HasKey(d => d.Id);

      HasOptional(d => d.DeathLocation);
    }
  }
}
