using FamilyTreeUI.DataLayer.Models;
using FamilyTreeUI.Relationships;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace FamilyTreeLogic.DataLayer.Models
{
  public class Person
  {
    public Person(Person relationshipOwner)
    {
      RelationshipOwner = relationshipOwner;
    }

    public Person()
    {
      
    }

    public RelationshipType RelationshipType { get; set; } 
    public virtual Tree Tree { get; set; }

    public int TreeId { get; set; }
    public virtual Person RelationshipOwner { get; set; }

    public virtual List<Person> DependentPeople { get; set; }

    public string RelationshipToHead { get; set; }
    public bool IsTreeOwner { get; set; }
    public int Id { get; set; }

    public virtual MainInfo MainInfo { get; set; }

    public virtual BurthInfo BurthInfo { get; set; }

    public virtual AdditionalInfo AdditionalInfo { get; set; }

    public virtual DeathInfo DeathInfo { get; set; }

    public virtual ObservableCollection<Education> Educations { get; set; }

    public virtual ObservableCollection<Residence> Residences { get; set; } 
  }
}
