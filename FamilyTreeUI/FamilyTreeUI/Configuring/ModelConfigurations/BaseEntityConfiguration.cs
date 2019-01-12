using System.Data.Entity.ModelConfiguration;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public abstract class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : class
  {
    public BaseEntityConfiguration()
    {
      Configure();
    }
    protected abstract void Configure();
  }
}
