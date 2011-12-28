using System;
using System.Windows.Input;

namespace designPatterns.viewmodel
{
    /// <summary>
    /// Command class for easier and cleaner creating command
    /// </summary>
    public class Command : ICommand
    {

        #region Properties

        // Predicate is delegate for returning boolean
        // Action is delegate for doing an action
        public Predicate<object> CanExcuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }
        
        #endregion

        public void Execute(object parameter) {
            if (ExecuteDelegate != null)
                ExecuteDelegate(parameter);
        }

        /// <summary>
        /// Check if the command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) {
            return CanExcuteDelegate == null || CanExcuteDelegate(parameter);
        }

        /// <summary>
        /// When you override this, you can trigger execute with another event
        /// when lose focus, user input ...
        /// </summary>
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested    += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
