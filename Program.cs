namespace multithreading
{
    class Program {

        static void Main(string[] args)
        {
            Filesystem fs = new Filesystem();
            fs.populateFilesystem(25, 10);
            Console.WriteLine("Files: " + fs.Enumerate().Count);
        }
    }
}
