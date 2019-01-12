using GraphX.PCL.Common.Models;

namespace FamilyTreeUI.GraphLogic
{
  public class DataEdge : EdgeBase<DataVertex>
  {
    public DataEdge(DataVertex source, DataVertex target, double weight = 1)
  : base(source, target, weight)
    {
    }

    public DataEdge()
        : base(null, null, 1)
    {
    }

    public override string ToString()
    {
      return string.Empty;
    }
  }
}
