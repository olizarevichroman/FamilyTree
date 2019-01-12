using FamilyTreeLogic.DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class CountyEntityConfiguration : BaseEntityConfiguration<Country>
  {
    protected override void Configure()
    {
      ToTable("Countries");

      HasKey(c => c.Id);

      Property(m => m.Id)
        .HasColumnName("CountryId")
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
        .IsRequired();

      Property(m => m.Title)
        .HasColumnName("CountryName")
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
        .IsRequired();
    }
  }
}
