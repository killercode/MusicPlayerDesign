
namespace MusicPlayerDesign.Models
{
    public class FileInfo
    {
        private string _sourceDirectory;
        private string _directory;
        private int _fileindex;
        private string _title;
        private string _artist;

        /// <summary>
        /// Source Directory to search mp3 Files
        /// </summary>
        /// <remarks>
        /// Not Used
        /// </remarks>
        public string SourceDirectory
        {
            get { return _sourceDirectory; }
            set { _sourceDirectory = value; }
        }
        
        /// <summary>
        /// Directory for each file
        /// </summary>
        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }
        
        /// <summary>
        /// Index of the client list for each file
        /// </summary>
        public int FileIndex
        {
            get { return _fileindex; }
            set { _fileindex = value; }
        }

        /// <summary>
        /// Title tag for each mp3 file
        /// </summary>
        public string Title
        {
            get { return _title; }
            set 
            { 
                if(value == null)
                {
                    _title = _directory;
                }
                else
                {
                    _title = value;
                }
                 
            }
        }
        
        /// <summary>
        /// Artist tag for each mp3 file
        /// </summary>
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
