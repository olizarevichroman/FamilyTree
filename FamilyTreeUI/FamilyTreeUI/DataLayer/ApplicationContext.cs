using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeLogic.Extensions;
using FamilyTreeUI.DataLayer.Models;
using System.Data.Entity;

namespace FamilyTreeLogic.DataLayer
{
  public class ApplicationContext : DbContext
  {
    public DbSet<MainInfo> MainInfos { get; set; }

    public DbSet<Tree> Trees { get; set; }
    public DbSet<Country> Countries { get; set; }

    public DbSet<Person> People { get; set; }

    public DbSet<BurthInfo> Burths { get; set; }

    public DbSet<DeathInfo> Deaths { get; set; }

    //public DbSet<AdditionalInfo> AdditionalInfos { get; set; }

    public DbSet<Residence> Residences { get; set; }

    public DbSet<LocationDetails> LocationDetails { get; set; }
    public ApplicationContext() : base("name=defaultConnection")
    {
      Database.CreateIfNotExists();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.ApplyConfigurations();
    }
  }
}
