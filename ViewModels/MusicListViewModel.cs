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
            if(!Directories.Any() )
            {
                CreateListofFiles();
                Console.WriteLine("\nExecuted");
            }
            else
            {
                Console.WriteLine("\nNot executed");
            }
        }

        public void CreateListofFiles()
        {
            List<string> mp3Files = Directory.EnumerateFiles(_sourceDirectory, "*.mp3").ToList();
            mp3Files.ToArray();

            for (int i = 0; i < mp3Files.Count; i++)
            {
                Directories.Insert(i,
                    new Models.FileInfo
                    {
                        Directory = mp3Files[i],
                        FileIndex = i,
                        //Title = "file " + i.ToString()
                        Title = TagLib.File.Create(mp3Files[i]).Tag.Title,
                        Artist = TagLib.File.Create(mp3Files[i]).Tag.FirstArtist
                    });
            }
        }



    }
}
