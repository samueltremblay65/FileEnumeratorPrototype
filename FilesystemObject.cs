namespace multithreading
{
    public abstract class FilesystemObject
    {
        private string name;
        private bool isDirectory;

        public FilesystemObject(string name, bool isDirectory)
        {
            this.name = name;
            this.isDirectory = isDirectory;
        }

        public string getFilename()
        {
            return name;
        }

        public bool IsDirectory()
        {
            return isDirectory;
        }
    }
}