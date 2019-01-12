using FamilyTreeLogic.DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTreeUI.Configuring.ModelConfigurations
{
  public class PersonEntityConfiguration : BaseEntityConfiguration<Person>
  {
    protected override void Configure()
    {
      //PK configuration
      HasKey(p => p.Id)
        .Property(p => p.Id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      HasMany(p => p.DependentPeople);

      //Relations with MainInfo configure
      HasRequired(p => p.MainInfo)
        .WithRequiredPrincipal(m => m.Person);

      //Relations with BurthInfo configure
      HasOptional(p => p.BurthInfo)
        .WithRequired(b => b.Person);

      //Relations with DeathInfo configure
      HasOptional(p => p.DeathInfo)
        .WithRequired(d => d.Person);

      //Relations with Residence configure
      HasMany(p => p.Residences)
        .WithRequired(r => r.Person)
        .HasForeignKey(r => r.PersonId);

      //Relations with AdditionalInfo configure
      HasOptional(p => p.AdditionalInfo)
        .WithRequired(a => a.Person);


      //Relations with Universities configure
      HasMany(p => p.Educations)
        .WithRequired(e => e.Person)
        .HasForeignKey(e => e.PersonId);
    }
  }
}
