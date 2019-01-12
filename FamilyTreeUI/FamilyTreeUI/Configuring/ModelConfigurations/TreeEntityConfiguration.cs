using FamilyTreeUI.DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class TreeEntityConfiguration : BaseEntityConfiguration<Tree>
  {
    protected override void Configure()
    {
      HasKey(t => t.Id)
        .Property(t => t.Id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      HasMany(t => t.People)
        .WithRequired(p => p.Tree)
        .HasForeignKey(p => p.TreeId);
    }
  }
}
