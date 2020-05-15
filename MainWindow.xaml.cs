using System.Windows;
using MusicPlayerDesign.ViewModels;

namespace MusicPlayerDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 8;
        }
    }
}
