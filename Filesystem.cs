namespace multithreading
{
    class Filesystem {

        List<FilesystemObject> entries;
        public Filesystem()
        {
            Console.WriteLine("Creating a new filesystem");
            entries = new List<FilesystemObject>();
        }

        public void populateFilesystem(int filesystemObjectCount, int levelBreadth)
        {
            var random = new Random();

            var fileContent = "This is a random file";

            List<FilesystemObject> filesystemObjectsList = new List<FilesystemObject>();
            List<FilesystemObject> parentList;

            // Generating filesystem objects for the first level
            for(int i = 0; i < filesystemObjectCount; i++)
            {
                FilesystemObject filesystemObject; 
                if(random.Next(0, 9) == 0)
                {
                    filesystemObject = new Directory("Dir" + i.ToString());
                }
                else
                {
                    filesystemObject = new File("File" + i.ToString(), fileContent);
                }

                filesystemObjectsList.Add(filesystemObject);
            }

            // Used for naming directories
            int directoryNumber = 0;

            // While we are still grouping and we have not arrived to root level
            while(filesystemObjectsList.Count != 1)
            {
                int index = 0;
                parentList = new List<FilesystemObject>();

                // While there are still elements without parents
                while(index < filesystemObjectsList.Count - 1)
                {
                    Directory parentDirectory = new Directory("ParentDirectory" + directoryNumber++.ToString());

                    // Generate a number of children
                    int numberChildren = random.Next(1, levelBreadth);

                    // Add this number of children to the parent directory
                    int i = 0;
                    while(i++ < numberChildren && index++ < filesystemObjectsList.Count - 1)
                    {
                        parentDirectory.AddFilesystemObject(filesystemObjectsList.ElementAt(index));
                    }

                    // Add the directory to the parent list
                    parentList.Add(parentDirectory);
                }

                filesystemObjectsList = parentList;
            }

            entries.Add(filesystemObjectsList.First());
        }

        // Returns a list of all files within 
        public List<File> Enumerate()
        {
            List<File> allFiles = new List<File>();

            Queue<Directory> directoryQueue = new Queue<Directory>();

            // Initial seeding
            foreach(FilesystemObject filesystemObject in entries)
            {
                if(filesystemObject.IsDirectory())
                {
                    directoryQueue.Enqueue((Directory)filesystemObject);
                }
                else
                {
                    allFiles.Add((File)filesystemObject);
                }
            }


            // Breadth first searching
            while(directoryQueue.Count > 0)
            {
                Directory directory = directoryQueue.Dequeue();
                List<FilesystemObject> filesystemObjects = directory.GetFilesystemObjects();
                foreach(FilesystemObject filesystemObject in filesystemObjects)
                {
                    if(filesystemObject.IsDirectory())
                    {
                        directoryQueue.Enqueue((Directory)filesystemObject);
                    }
                    else
                    {
                        allFiles.Add((File)filesystemObject);
                    }
                }
            }

            return allFiles;
        }
    }
}
