using System.Windows.Input;
using MusicPlayerDesign.Commands;
using System.ComponentModel;
using System.Windows;

namespace MusicPlayerDesign.ViewModels
{
    /// <summary>
    /// Model of the Main View
    /// </summary>
    public class MainViewModel:BaseViewModel, INotifyPropertyChanged 
    {
        private BaseViewModel _selectedViewModel;
        private WindowState _state = WindowState.Normal;

        /// <summary>
        /// Store the Selected ViewModel, when setted triggers the OnPropertyChanged Event
        /// </summary>
        /// <remarks>
        /// When this property is set, triggers OnPropertyChanged
        /// </remarks>
        public BaseViewModel SelectedViewModel
        {
            get { 
                if (_selectedViewModel == null )
                {
                    _selectedViewModel = new MusicListViewModel();
                }
                return _selectedViewModel; }
            set { _selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }

        /// <summary>
        /// Stores the state of the window, if settted triggers the OnPropertyChanged Event
        /// </summary>
        /// <remarks>
        /// When this property is set, triggers OnPropertyChanged
        /// </remarks>
        public WindowState state
        {
            get { return _state; }
            set { _state = value; OnPropertyChanged("state"); }
        }

        /// <summary>
        /// View Changer
        /// </summary>
        public ICommand ViewChanger { get; set; }

        /// <summary>
        /// Dock Buttons
        /// </summary>
        public ICommand DockButtons { get; set; }

        /// <summary>
        /// MainViewModel Constructor
        /// </summary>
        public MainViewModel()
        {
            ViewChanger = new ViewChanger(this);
            DockButtons = new DockButtons(this);
        }
    }
}
