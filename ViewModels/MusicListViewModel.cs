using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayerDesign.Commands;
using System.Windows.Input;
using MusicPlayerDesign.Models;
using MusicPlayerDesign.Views;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MusicPlayerDesign.ViewModels
{
    public class MusicListViewModel:BaseViewModel
    {
        private string _sourceDirectory = @"C:\Users\ricar\Music\Música";
        
        private ObservableCollection<Models.FileInfo> _directories = new ObservableCollection<Models.FileInfo>();
        public ObservableCollection<Models.FileInfo> Directories 
        { 
            get { return _directories; } 
            set { _directories = value; OnPropertyChanged("Directories"); } 
        }
        
        private ObservableCollection<string> mp3Files = new ObservableCollection<string>();
        
        //_____________________________________________________ Constructor ____________________________________________________
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
                        Artist = TagLib.File.Create(mp3Files[i]).Tag.FirstArtist
                    };
                    
                    App.Current.Dispatcher.Invoke((System.Action)delegate
                    {
                        Directories.Add(fileInfo);
                    });

                });
                
            }


        }

       
    }
}


//___________________________________________________________________________________________________________________________________________________________________________________









