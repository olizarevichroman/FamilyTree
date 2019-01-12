using System;
using System.Reflection;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;
using FamilyTreeUI.Configuring.ModelConfigurations;

namespace FamilyTreeLogic.Extensions
{
  public static class ConfigurationRegistrarExtensions
  {
    public static void ApplyConfigurations(this ConfigurationRegistrar configurationRegistrar)
    {
      var executingAssembly = Assembly.GetExecutingAssembly();

      var configurationTypes = executingAssembly.GetTypes()
        .Where(t => !t.IsAbstract
                && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityConfiguration<>));

      foreach (var config in configurationTypes)
      {
        dynamic configuration = Activator.CreateInstance(config);

        configurationRegistrar.Add(configuration);
      }
    }
  }
}
