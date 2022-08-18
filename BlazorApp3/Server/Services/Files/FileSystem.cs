namespace BlazorApp3.Server.Services.Files
{
    public class FileSystem
    {
        internal string Root;
        internal string Path(string fileName) => string.Format("{Root}/{fileName}", Root, fileName);
        public FileSystem(string root) => Root = root;
        FileStream OpenSafely(string fileName)
        {
            FileStream file;
            if (File.Exists(Path(fileName)))
                file = new FileStream(Path(fileName), FileMode.Append);
            else
                file = new FileStream(Path(fileName), FileMode.OpenOrCreate);
            return file;
        }

        bool ConfirmDeletion(string fileName)
        {
            if (File.Exists(Path(fileName)))
                File.Delete(Path(fileName));
            else return true; // no file to delete.
            if (!File.Exists(Path(fileName)))
                return true;
            return false; // failed to delete the file
        }

        public IEnumerable<string> ListFiles()
        {
            foreach (var file in Directory.GetFiles(Root))
                yield return file; // return each file as soon as it's available
        }

        public bool Delete(string fileName) => ConfirmDeletion(fileName);

        public FileStream Open(string fileName) => OpenSafely(fileName);

        public StreamReader Read(string fileName) => new StreamReader(OpenSafely(fileName));

        public FileStream Save(string fileName) => OpenSafely(fileName);
    }
}
