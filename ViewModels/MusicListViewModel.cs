using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace MusicPlayerDesign.ViewModels
{
    /// <summary>
    /// ViewModel that display the MusicList
    /// </summary>
    public class MusicListViewModel:BaseViewModel
    {
        private string _sourceDirectory = @"C:\Users\ricar\Music\Música";
        
        private ObservableCollection<Models.FileInfo> _directories = new ObservableCollection<Models.FileInfo>();

        private ObservableCollection<string> mp3Files = new ObservableCollection<string>();

        public ObservableCollection<Models.FileInfo> Directories
        { 
            get { return _directories; } 
            set { _directories = value; OnPropertyChanged("Directories"); } 
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public MusicListViewModel()
        {
            CreateFileInfoAsync();
        }

        private async void CreateFileInfoAsync()
        {
            await Task.Factory.StartNew(() => {
                mp3Files = new ObservableCollection<string>(Directory.EnumerateFiles(_sourceDirectory, "*.mp3"));
            });

            for (int i = 0; i < mp3Files.Count; i++)
            {
                await Task.Run(() =>
                {
                    Models.FileInfo fileInfo = new Models.FileInfo
                    {
                        Directory = mp3Files[i],
                        FileIndex = i,
                        Title = TagLib.File.Create(mp3Files[i]).Tag.Title,
                        Artist = !string.IsNullOrEmpty(TagLib.File.Create(mp3Files[i]).Tag.FirstPerformer) ? 
                                 TagLib.File.Create(mp3Files[i]).Tag.FirstPerformer : 
                                 TagLib.File.Create(mp3Files[i]).Tag.FirstAlbumArtist
                    };
                    
                    App.Current.Dispatcher.Invoke(delegate
                    {
                        Directories.Add(fileInfo);
                    });
                });   
            }
        }      
    }
}









