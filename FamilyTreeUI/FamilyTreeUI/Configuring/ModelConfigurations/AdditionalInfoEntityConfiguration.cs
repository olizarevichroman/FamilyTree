using FamilyTreeLogic.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class AdditionalInfoEntityConfiguration : BaseEntityConfiguration<AdditionalInfo>
  {
    protected override void Configure()
    {
      HasKey(a => a.Id);

      HasMany(a => a.Professions)
        .WithRequired(p => p.AdditionalInfo)
        .HasForeignKey(p => p.AdditionalInfoId);

      HasRequired(a => a.Person)
        .WithOptional(p => p.AdditionalInfo);
    }
  }
}
