using FamilyTreeLogic.DataLayer.Abstractions;
using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.Relationships;
using FamilyTreeUI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace FamilyTreeUI
{
  /// <summary>
  /// Interaction logic for NewFamilyMember.xaml
  /// </summary>
  public partial class FamilyMember : Window
  {
    /// <summary>
    /// Creates and shows family member dialog. Use it to create new tree owner
    /// </summary>
    public FamilyMember(IUnitOfWork unitOfWork, ObservableCollection<Person> treeOwners)
    {
      InitializeComponent();
      this.DataContext = new FamilyMemberViewModel(unitOfWork, treeOwners);
    }

    public FamilyMember(Person personToEdit)
    {
      InitializeComponent();
      this.DataContext = new FamilyMemberViewModel(personToEdit);
    }

    /// <summary>
    /// Creates and shows family member dialog for editing or creating new relationship
    /// </summary>
    /// <param name="person">Passed person</param>
    /// <param name="isEditMode">Shows is it edit mode or it have to create new relationship</param>
    public FamilyMember(Person person, IRelationshipSetter relationshipSetter, IUnitOfWork unitOfWork)
    {
      InitializeComponent();
      this.DataContext = new FamilyMemberViewModel(person, relationshipSetter, unitOfWork);
    }
  }
}
