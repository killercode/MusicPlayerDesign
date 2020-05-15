using System.Windows.Controls;
using MusicPlayerDesign.ViewModels;

namespace MusicPlayerDesign.Views
{
    /// <summary>
    /// Interaction logic for MusicListView.xaml
    /// </summary>
    public partial class MusicListView : UserControl
    {
        public MusicListView()
        {
            InitializeComponent();
            // TODO: Remove this! It will call the constructors 2 times
            //DataContext = new MusicListViewModel();
        }
    }
}
