namespace multithreading
{
    public class File : FilesystemObject
    {
        private string contents;
    
        public File(string name, string contents): base(name, false)
        {
            this.contents = contents;
        }
    }
}