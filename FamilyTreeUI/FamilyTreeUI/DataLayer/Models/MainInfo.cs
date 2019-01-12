namespace FamilyTreeLogic.DataLayer.Models
{
  public enum Sex
  {
    Male, Female
  }
  public class MainInfo
  {
    public int Id { get; set; }
    public string LastName { get; set; }

    public string Name { get; set; }
    public string Patronymic { get; set; }

    public string MaidenName { get; set; }

    public string FullName => $"{LastName} {Name} {Patronymic}";
    public Sex Sex { get; set; }
    public virtual Person Person {get;set;}
  }
}
