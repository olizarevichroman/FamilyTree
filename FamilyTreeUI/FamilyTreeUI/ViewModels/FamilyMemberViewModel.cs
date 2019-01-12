using FamilyTreeLogic.DataLayer.Abstractions;
using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.Commands;
using FamilyTreeUI.DataLayer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FamilyTreeUI.Extensions;
using System.Windows;
using FamilyTreeUI.Relationships;
using FamilyTreeUI.TreeService;

namespace FamilyTreeUI.ViewModels
{
  public class FamilyMemberViewModel
  {
    private RelayCommand<Education> _deleteUniversityCommand;

    private IRelationshipSetter _relationshipSetter;

    private IRelarionshipResolver _relationshipResolver;

    private ObservableCollection<Person> _treeOwners;

    private Tree _tree;

    private RelayCommand<object> _addEducationRecord;

    private RelayCommand<Window> _addRecordCommand;

    private RelayCommand<object> _addResidenceRecordCommand;

    private RelayCommand<Residence> _deleteResidenceCommand;

    private RelayCommand<object> _addProfessionRecordCommand;

    private RelayCommand<Profession> _deleteProfessionCommand;

    private Person _relationshipOwner;

    /// <summary>
    /// Use to create new relationship
    /// </summary>
    /// <param name="relatiinshipOwner">Relationship owner. New member will attached to it</param>
    /// <param name="newFamilyMember">New family member which will be attached to the relaonship owner</param>
    public FamilyMemberViewModel(Person relationshipOwner, IRelationshipSetter relationshipSetter, IUnitOfWork unitOfWork)
    {
      _relationshipResolver = new RelationshipResolver();
      this.unitOfWork = unitOfWork;
      _relationshipOwner = relationshipOwner;
      _tree = _relationshipOwner.Tree;
      Person = CreateNewPerson(false);
      _relationshipSetter = relationshipSetter;
      _addRecordCommand = new RelayCommand<Window>(AddNewRelationship);
    }

    /// <summary>
    /// Creates new person with related tree
    /// </summary>
    /// <returns>Created person</returns>
    private Person CreateNewPerson(bool isTreeOwner)
    {
      var newPerson = new Person
      {
        IsTreeOwner = isTreeOwner,
        Tree = _tree,
        MainInfo = new MainInfo(),
        AdditionalInfo = new AdditionalInfo
        {
          Professions = new ObservableCollection<Profession>()
        },
        BurthInfo = new BurthInfo
        {
          BurthLocation = new LocationDetails()
        },
        Educations = new ObservableCollection<Education>(),
        DependentPeople = new List<Person>(),
        DeathInfo = new DeathInfo
        {
          DeathLocation = new LocationDetails()
        },
        Residences = new ObservableCollection<Residence>()
      };


      return newPerson;
    }


    public FamilyMemberViewModel(Person personToEdit)
    {
      Person = personToEdit;
    }
    /// <summary>
    /// Default constructor. Use to create new tree with it's owner
    /// </summary>
    public FamilyMemberViewModel(IUnitOfWork unitOfWork, ObservableCollection<Person> treeOwners)
    {
      _treeOwners = treeOwners;

      this.unitOfWork = unitOfWork;

      unitOfWork.CountriesRepository.LoadLocal();
      Countries = unitOfWork.CountriesRepository.GetLocal();

      _addRecordCommand = new RelayCommand<Window>(AddRecord);

      _tree = new Tree();

      Person = CreateNewPerson(true);        
    }
    public Person Person { get; set; }

    private IUnitOfWork unitOfWork; 

    public IEnumerable<Country> Countries { get; set; }

    #region Commands
    public RelayCommand<Profession> DeleteProfessionCommand
    {
      get
      {
        return _deleteProfessionCommand ??
          (_deleteProfessionCommand = new RelayCommand<Profession>(p =>
          {
            Person.AdditionalInfo.Professions.Remove(p);
          }));
      }
    }
    public RelayCommand<object> AddProfessionRecordCommand
    {
      get
      {
        return _addProfessionRecordCommand ??
          (_addProfessionRecordCommand = new RelayCommand<object>(AddProfessionRecord));
      }
    }

    public RelayCommand<Residence> DeleteResidenceCommand
    {
      get
      {
        return _deleteResidenceCommand ??
          (_deleteResidenceCommand = new RelayCommand<Residence>(DeleteResidenceRecord));
      }
    }
    public RelayCommand<Education> DeleteUniversityCommand
    {
      get
      {
        return _deleteUniversityCommand ??
          (_deleteUniversityCommand = new RelayCommand<Education>(u =>
          {
            Person.Educations.Remove(u);
          }));
      }
    }
    
    public RelayCommand<object> AddEducationRecordCommand
    {
      get
      {
        return _addEducationRecord ?? (_addEducationRecord = new RelayCommand<object>(AddEducationRecord));
      }
    }
    public RelayCommand<object> AddResidenceRecordCommand
    {
      get
      {
        return _addResidenceRecordCommand ??
          (_addResidenceRecordCommand = new RelayCommand<object>(AddResidenceRecord));
      }
    }
    public RelayCommand<Window> AddRecordCommand
    {
      get
      {
        return _addRecordCommand;
      }
    }

    #endregion 

    #region Commands Methods
    private void AddNewRelationship(Window window)
    {
      _relationshipSetter.SetRelationship(_relationshipOwner, Person);

      Person.RelationshipOwner = _relationshipOwner;

      _relationshipResolver.Resolve(Person);

      unitOfWork.PersonRepository.Add(Person);
      unitOfWork.Complete();
      window.Close();
    }
    private void AddProfessionRecord(object dummy)
    {
      Person.AdditionalInfo.Professions.Add(new Profession());
    }
    private void DeleteResidenceRecord(Residence residence)
    {
      Person.Residences.Remove(residence);
    }

    private void AddResidenceRecord(object residence)
    {
      Person.Residences.Add(new Residence
      {
        Location = new LocationDetails()
      });
    }
    private void AddEducationRecord(object dummy)
    {
      Person.Educations.Add(new Education());
    }
    private void AddRecord(Window currrentWindow)
    {
      
      Person.RelationshipToHead = "Обратившийся";
      unitOfWork.TreeRepository.Add(_tree);
      unitOfWork.Complete();
      unitOfWork.PersonRepository.Add(Person);
      unitOfWork.Complete();
      _treeOwners.Add(Person);
      currrentWindow.Close();
    }

    #endregion
  }
}
