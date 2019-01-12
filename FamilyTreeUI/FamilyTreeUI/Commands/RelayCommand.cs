using System;
using System.Windows.Input;

namespace FamilyTreeUI.Commands
{
  public class RelayCommand<T> : ICommand where T:class
  {
    private Action<T> execute;
    private Func<T, bool> canExecute;

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
    {
      this.execute = execute;
      this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
      var p = parameter as T;
      return this.canExecute == null || this.canExecute(p);
    }

    public void Execute(object parameter)
    {
      var p = parameter as T;
      this.execute(p);
    }
  }
}
