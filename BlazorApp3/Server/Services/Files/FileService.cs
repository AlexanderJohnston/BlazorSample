using BlazorApp3.Server.Services.Files.Configuration;
using BlazorApp3.Server.Services.Files.Contracts;
using Microsoft.Extensions.Options;

namespace BlazorApp3.Server.Services.Files
{
    public class FileService : IFileService
    {
        readonly FileSystem _fileSystem;

        public FileService(IOptions<FileSystemOptions> options) => _fileSystem = new FileSystem(options.Value.Directory);

        public bool Delete(string fileId) => _fileSystem.Delete(fileId);

        public FileStream Get(string fileId) => _fileSystem.Open(fileId);

        public IEnumerable<string> GetFiles() => _fileSystem.ListFiles();

        public void Save(byte[] data, string name)
        {
            using(var file = _fileSystem.Save(name))
            {
                file.Write(data, 0, data.Length);
            }
        }
    }
}
