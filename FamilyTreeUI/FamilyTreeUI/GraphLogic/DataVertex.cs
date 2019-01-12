using FamilyTreeLogic.DataLayer.Models;
using GraphX.PCL.Common.Models;
using System;

namespace FamilyTreeUI.GraphLogic
{
  public class DataVertex : VertexBase
  {

    public DataVertex(Person person)
    {
      Text = $"{person.MainInfo.FullName}{Environment.NewLine}{person.RelationshipToHead}";
      ID = person.Id;
    }

    public DataVertex() { }

    public string Text { get; set; }

    public override string ToString()
    {
      return Text;
    }
  }
}
