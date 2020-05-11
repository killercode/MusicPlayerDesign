using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace MusicPlayerDesign.Models
{
    public class FileInfo
    {
        //____________________ Source Directory to search mp3 files (##NOT USED##) ____________________
        private string _sourceDirectory;
        public string SourceDirectory
        {
            get { return this._sourceDirectory; }
            set { this._sourceDirectory = value; }
        }

        //____________________ Directory for each file ____________________
        private string _directory;
        public string Directory
        {
            get { return this._directory; }
            set { this._directory = value; }
        }

        //____________________ Index of client list for each file ____________________
        private int _fileindex;
        public int FileIndex
        {
            get { return this._fileindex; }
            set { this._fileindex = value; }
        }

        //____________________ Title tag for each mp3 file ____________________
        private string _title;
        public string Title
        {
            get { return this._title; }
            set 
            { 
                if(value == null)
                {
                    this._title = this._directory;
                }
                else
                {
                    this._title = value;
                }
                 
            }
        }

        //____________________ Artist tag for each mp3 file ____________________
        private string _artist;
        public string Artist
        {
            get { return this._artist; }
            set
            {
                if (value == null)
                {
                    this._artist = "...";
                }
                else
                {
                    this._artist = value;
                }

            }
        }



    }
}
