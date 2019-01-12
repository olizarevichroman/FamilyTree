using FamilyTreeLogic.DataLayer;
using FamilyTreeLogic.DataLayer.Implementations;
using FamilyTreeUI.DataLayer.Abstractions;
using FamilyTreeUI.DataLayer.Models;

namespace FamilyTreeUI.DataLayer.Implementations
{
  public class TreeRepository : Repository<Tree>, ITreeRepository
  {
    public TreeRepository(ApplicationContext context) : base(context)
    {
    }
  }
}
