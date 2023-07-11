namespace multithreading
{
    public class Directory : FilesystemObject
    {
        private List<FilesystemObject> entries;
    
        public Directory(string name): base(name, true)
        {
            this.entries = new List<FilesystemObject>();
        }

        public Directory(string name, List<FilesystemObject> entries): base(name, true)
        {
            this.entries = entries;
        }

        public void AddFilesystemObject(FilesystemObject entry)
        {
            entries.Add(entry);
        }

        public List<FilesystemObject> GetFilesystemObjects()
        {
            return entries;
        }
    }
}