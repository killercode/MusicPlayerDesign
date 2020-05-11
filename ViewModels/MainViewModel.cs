using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPlayerDesign.Commands;
using System.ComponentModel;
using System.Windows;

namespace MusicPlayerDesign.ViewModels
{
    public class MainViewModel:BaseViewModel, INotifyPropertyChanged 
    {
        private BaseViewModel _selectedViewModel = new MusicListViewModel();
        private WindowState _state = WindowState.Normal;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }

        public WindowState state
        {
            get { return _state; }
            set { _state = value; OnPropertyChanged("state"); }
        }


        public ICommand ViewChanger { get; set; }
        public ICommand DockButtons { get; set; }

        public MainViewModel()
        {
            ViewChanger = new ViewChanger(this);
            DockButtons = new DockButtons(this);
        }
    }
}
