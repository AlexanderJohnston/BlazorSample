namespace BlazorApp3.Server.Services.Files.Contracts
{
    public interface IFileService
    {
        public IEnumerable<string> GetFiles();
        public FileStream Get(string fileId);
        public bool Delete(string fileId);
        public void Save(byte[] data, string name);
    }
}
