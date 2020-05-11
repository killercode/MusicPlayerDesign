using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPlayerDesign.ViewModels;
using System.Windows;

namespace MusicPlayerDesign.Commands
{
    public class ViewChanger:ICommand
    {
        private MainViewModel viewModel;
        public ViewChanger(MainViewModel viewModel)
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
            //MessageBox.Show(parameter.ToString());

            if (parameter.ToString() == "ChooseFolder" && viewModel.SelectedViewModel.ToString() == "MusicPlayerDesign.ViewModels.AddFolderViewModel")
            {
                viewModel.SelectedViewModel = new MusicListViewModel();
            }
            else if (parameter.ToString() == "ChooseFolder" && viewModel.SelectedViewModel.ToString() == "MusicPlayerDesign.ViewModels.MusicListViewModel")
            {
                viewModel.SelectedViewModel = new AddFolderViewModel();
            }
        }
    }
}
