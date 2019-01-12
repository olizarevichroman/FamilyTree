using FamilyTreeUI.ViewModels;
using GraphX.Controls;
using System;
using System.Windows;

namespace FamilyTreeUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, IDisposable
  {
    public MainWindow()
    {
      InitializeComponent();

      ZoomControl.SetViewFinderVisibility(zoomctrl, Visibility.Visible);
      zoomctrl.ZoomToFill();    
    }

    public void Dispose()
    {
      (DataContext as MainViewModel).Dispose();
    }

    private void WindowClosed(object sender, EventArgs e)
    {
      Dispose();
    }
  }
}
