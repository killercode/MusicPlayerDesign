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

namespace MusicPlayerDesign.ViewModels
{
    public class MusicListViewModel:BaseViewModel
    {
        private string _sourceDirectory = @"C:\Users\ricar\Music\Música";
        private List<Models.FileInfo> _directories = new List<Models.FileInfo>();

        public List<Models.FileInfo> Directories 
        { 
            get { return _directories; } 
            set { _directories = value; } 
        }

        
        public MusicListViewModel()
        {
            ExecuteRunAsync();
        }

        private async void ExecuteRunAsync()
        {
            await RunAsync();
        }




        private async Task RunAsync()
        {
            List<string> dirs = FilePaths();

            for (int i = 0; i < dirs.Count; i++)
            {
                Models.FileInfo fileInfoItem = await Task.Run(() => CreateFileInfoAsync(dirs[i], i));
                Directories.Add(fileInfoItem);
            }

        }



        private async Task<Models.FileInfo> CreateFileInfoAsync(string file, int i)
        {
            Models.FileInfo fileInfo = await Task.Run(() => new Models.FileInfo
            {
                Directory = file,
                FileIndex = i,
                Title = TagLib.File.Create(file).Tag.Title,
                Artist = TagLib.File.Create(file).Tag.FirstArtist
            });

            return fileInfo;
        }




        private List<string> FilePaths()
        {
            List<string> dirs = Directory.EnumerateFiles(_sourceDirectory, "*.mp3").ToList();
            return dirs;
        }

       
    }
}


//___________________________________________________________________________________________________________________________________________________________________________________









