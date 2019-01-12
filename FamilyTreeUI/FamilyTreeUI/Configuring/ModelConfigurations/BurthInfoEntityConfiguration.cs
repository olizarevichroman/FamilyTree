using FamilyTreeLogic.DataLayer.Models;
using System;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class BurthInfoEntityConfiguration : BaseEntityConfiguration<BurthInfo>
  {
    protected override void Configure()
    {
      HasKey(b => b.Id);

      HasOptional(l => l.BurthLocation);        
    }
  }
}
