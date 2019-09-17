using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpfui2.IODirectory.Data.ViewModels
{
    public class RelayCommand : ICommand
    {

        Action MyAction { get; set; }

        /// <summary>
        /// The event that's fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            MyAction = action;
        }

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            MyAction();
        }
    }
}
