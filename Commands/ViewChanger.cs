using System;
using System.Windows.Input;
using MusicPlayerDesign.ViewModels;
using System.Windows;

namespace MusicPlayerDesign.Commands
{
    /// <summary>
    /// ViewChanger Command
    /// </summary>
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
            // Weird stuff??? It can ALWAYS be executed!
            return true;
        }

        public void Execute(object parameter)
        {
            // Note to the original developer:
            // Guess what will happen if send a null! NPE FTW!
            // For the sake of maintenability I would stongly sugest to refactor this!

            if (parameter.ToString() == "OpenCurrentMusicPlay")
            {
                MessageBox.Show("Music");
            }

            if (parameter.ToString() == "ChooseFolder" && viewModel.SelectedViewModel is AddFolderViewModel)
            {
                viewModel.SelectedViewModel = new MusicListViewModel();
            }
            else if (parameter.ToString() == "ChooseFolder" && viewModel.SelectedViewModel is MusicListViewModel)
            {
                viewModel.SelectedViewModel = new AddFolderViewModel();
            }
        }
    }
}
