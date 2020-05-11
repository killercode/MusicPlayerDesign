using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPlayerDesign.ViewModels;
using System.Windows;
using MusicPlayerDesign;

namespace MusicPlayerDesign.Commands
{
    public class DockButtons : ICommand
    {
        private MainViewModel viewModel;
        public DockButtons(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
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
