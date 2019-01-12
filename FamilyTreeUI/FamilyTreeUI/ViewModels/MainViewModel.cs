using FamilyTreeLogic.DataLayer.Abstractions;
using FamilyTreeLogic.DataLayer.Implementations;
using FamilyTreeLogic.DataLayer.Models;
using FamilyTreeUI.Commands;
using FamilyTreeUI.DataLayer.Models;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FamilyTreeUI.Relationships;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using FamilyTreeUI.Extensions;
using FamilyTreeUI.GraphLogic;
using GraphX.Controls;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms.LayoutAlgorithms;
using System;

namespace FamilyTreeUI.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged, IDisposable
  {
    private IUnitOfWork _unifOfWork;

    public RoutedCommand OpenDialogCommand = DialogHost.OpenDialogCommand;

    private ObservableCollection<Person> _treeOwners;

    private GXLogicCoreFamily _graphCoreLogic = new GXLogicCoreFamily();

    private readonly IRelationshipProvider _relationshipProvider;

    private ObservableCollection<Person> _currentTreePeople;

    private RelayCommand<Person> _switchTreeCommand;

    private RelayCommand<Person> _addNewContactCommand;

    private RelayCommand<Button> _addNewRelationshipCommand;

    private RelayCommand<Person> _editPersonCommand;

    private static RelayCommand<Button> _calculateAccessableRelationshipsCommand;

    private Tree _currentTree;

    private FamilyGraphArea _familyGraphArea = new FamilyGraphArea();
    public FamilyGraphArea FamilyGraphArea
    {
      get => _familyGraphArea;
      set
      {
        _familyGraphArea = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FamilyGraphArea)));
      }
    }

    public Person SelectedPerson { get; set; }

    public RelayCommand<Button> CalculateAccessableRelationshipsCommand
    {
      get
      {
        return _calculateAccessableRelationshipsCommand ??
          (_calculateAccessableRelationshipsCommand = new RelayCommand<Button>(CalculateAccessableRelationships));
      }
    }

    private void CalculateAccessableRelationships(Button button)
    {
      var selectedPerson = (button.TemplatedParent as ContentPresenter).Content as Person;

      SelectedPerson = selectedPerson;

      SelectedPersonRelationships = _relationshipProvider.GetRelationships(selectedPerson).ToList();

      var dialog = button.Tag as IInputElement;

      OpenDialogCommand.Execute(null, dialog);
    }

    private List<IRelationshipSetter> _selectedPersonRelationships;
    public List<IRelationshipSetter> SelectedPersonRelationships
    {
      get
      {
        return _selectedPersonRelationships;
      }
      set
      {
        _selectedPersonRelationships = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPersonRelationships)));
      }
    }

    public Tree CurrentTree
    {
      get
      {
        return _currentTree;
      }
      set
      {
        _currentTree = value;
        PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentTree)));
      }
    }

    public ObservableCollection<Person> TreeOwners
    {
      get
      {
        return _treeOwners;
      }
      set
      {
        _treeOwners = value;
      }
    }

    public ObservableCollection<Person> CurrentTreePeople
    {
      get
      {
        return _currentTreePeople;
      }
      set
      {
        _currentTreePeople = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTreePeople)));
      }
    }

    public RelayCommand<Person> EditPersonCommand
    {
      get
      {
        return _editPersonCommand ??
          (_editPersonCommand = new RelayCommand<Person>(EditPerson));
      }
    }

    public RelayCommand<Person> AddNewContactCommmand
    {
      get
      {
        return _addNewContactCommand ??
          (_addNewContactCommand = new RelayCommand<Person>(obj =>
          {
            var newFamilyMemberWindow = new FamilyMember(_unifOfWork, TreeOwners);
            newFamilyMemberWindow.ShowDialog();
          }));
      }
    }

    

    public event PropertyChangedEventHandler PropertyChanged;

    public RelayCommand<Person> SwitchTreeCommand
    {
      get
      {
        return _switchTreeCommand ??
          (_switchTreeCommand = new RelayCommand<Person>(SwitchTree));
      }
    }

    
    public RelayCommand<Button> AddNewRelationshipCommand
    {
      get
      {
        return _addNewRelationshipCommand ??
          (_addNewRelationshipCommand = new RelayCommand<Button>(AddNewRelatonship));
      }
    }

    private void SwitchTree(Person treeOwner)
    {
      var nextTree = treeOwner.Tree;

      CurrentTreePeople = nextTree.People;
 
    }

    private void EditPerson(Person person)
    {
      var editFamilyMemberDialog = new FamilyMember(person);
      editFamilyMemberDialog.ShowDialog();
    }

    private void AddNewRelatonship(Button button)
    {
      var relationshipOwner = button.Tag as Person;
      var relationshipSetter = button.DataContext as IRelationshipSetter;
      var familyMemberDialog = new FamilyMember(relationshipOwner, relationshipSetter, _unifOfWork);
      familyMemberDialog.ShowDialog();
    }

    public MainViewModel()
     {
      _unifOfWork = new UnitOfWork();

      _relationshipProvider = new RelationshipProvider();

      _unifOfWork.PersonRepository.LoadLocal();

      TreeOwners = new ObservableCollection<Person>(_unifOfWork.PersonRepository
        .GetLocal()
        .Where(p => p.IsTreeOwner == true)
        .OrderBy(p => p.TreeId));       
    }

    private RelayCommand<ZoomControl> _updateVisualTreeCommand;

    public RelayCommand<ZoomControl> UpdateTreeCommand
    {
      get
      {
        return _updateVisualTreeCommand ??
          (_updateVisualTreeCommand = new RelayCommand<ZoomControl>(UpdateVisualtree));
      }
    }

    private void UpdateVisualtree(ZoomControl zoomControl)
    {
      FamilyGraphArea = GraphAreaSetup(zoomControl);
    }

    private FamilyGraphArea GraphAreaSetup(ZoomControl zoomControl)
    {
      var logicCore = GraphLogicCoreSetup();
      var area = new FamilyGraphArea
      {
        LogicCore = logicCore
      };

      area.GenerateGraph(true, true);

      area.SetEdgesDashStyle(EdgeDashStyle.Dash);

      area.ShowAllEdgesArrows(false);

      area.ShowAllEdgesLabels(true);

      zoomControl.ZoomToFill();
      area.RelayoutGraph();
      zoomControl.ZoomToFill();

      return area;
    }

    private GXLogicCoreFamily GraphLogicCoreSetup()
    {
      var logicCore = new GXLogicCoreFamily
      {
        Graph = DataGraphSetup()
      };

      logicCore.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.BoundedFR;
      logicCore.DefaultLayoutAlgorithmParams = logicCore.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.KK);
      ((KKLayoutParameters)logicCore.DefaultLayoutAlgorithmParams).MaxIterations = 100;

      logicCore.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
      logicCore.DefaultOverlapRemovalAlgorithmParams.HorizontalGap = 50;
      logicCore.DefaultOverlapRemovalAlgorithmParams.VerticalGap = 50;
      logicCore.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER;
      logicCore.AsyncAlgorithmCompute = false;

      return logicCore;
    }

    private FamilyGraph DataGraphSetup()
    {
      var dataGraph = new FamilyGraph();

      var treeOwner = CurrentTreePeople.First(p => p.IsTreeOwner);

      var vertexToVertex = new List<KeyValuePair<int,int>>();

      CreateGraphVertex(dataGraph, treeOwner, vertexToVertex);
      CreateGraphEdges(dataGraph, vertexToVertex);

      return dataGraph;
    }

    private void CreateGraphEdges(FamilyGraph graph, List<KeyValuePair<int, int>> vertexToVertex)
    {
      var verticles = graph.Vertices.ToList();
      
      foreach (var vTv in vertexToVertex)
      {
        var from = verticles.First(d => d.ID == vTv.Key);
        var to = verticles.First(d => d.ID == vTv.Value);

        graph.AddEdge(new DataEdge(from, to));
      }
    }
    private void CreateGraphVertex(FamilyGraph graph, Person node, List<KeyValuePair<int, int>> vertexToVertex)
    {
      foreach (var dependent in node.DependentPeople)
      {
        CreateGraphVertex(graph, dependent, vertexToVertex);
      }

      if (node.RelationshipOwner == null)
      {
        return;
      }
     
      if (graph.Vertices.Where(dv => dv.ID == node.Id).Count() == 0)
      { 
        graph.AddVertex(new DataVertex(node));
      }

      if (graph.Vertices.Where(dv => dv.ID == node.RelationshipOwner.Id).Count() == 0)
      {
        graph.AddVertex(new DataVertex(node.RelationshipOwner));
      }
      
      vertexToVertex.Add(new KeyValuePair<int, int>(node.RelationshipOwner.Id, node.Id));
    }

    public void Dispose()
    {
      FamilyGraphArea.Dispose();
      _unifOfWork.Dispose();
    }
  }
}
