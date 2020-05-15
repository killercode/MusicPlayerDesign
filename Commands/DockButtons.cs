using System;
using System.Windows.Input;
using MusicPlayerDesign.ViewModels;
using System.Windows;


namespace MusicPlayerDesign.Commands
{
    /// <summary>
    /// Button Dock
    /// </summary>
    public class DockButtons : ICommand
    {
        private MainViewModel viewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewModel">ViewModel</param>
        public DockButtons(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // Weird stuff??? It can ALWAYS be execute!
            return true;
        }

        public void Execute(object parameter)
        {
            // Note to the original developer:
            // Guess what will happen if send a null! NPE FTW!
            if(parameter.ToString() == "Close")
            {
                App.Current.Shutdown();
            }

            if (parameter.ToString() == "Minimize")
            {
                viewModel.state = WindowState.Minimized;
            }

            if (parameter.ToString() == "Resize")
            {
                if(viewModel.state == WindowState.Maximized)
                {
                    viewModel.state = WindowState.Normal;
                }
                else if (viewModel.state == WindowState.Normal)
                {
                    viewModel.state = WindowState.Maximized;
                }
            }
        }
    }
}
