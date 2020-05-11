using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPlayerDesign.Commands;

namespace MusicPlayerDesign.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new MusicListViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }

        public ICommand ViewChanger { get; set; }

        public MainViewModel()
        {
            ViewChanger = new ViewChanger(this);
        }
    }
}
