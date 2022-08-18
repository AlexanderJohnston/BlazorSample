namespace BlazorApp3.Server.Services.Files
{
    public class FileUpload
    {
        public byte[] Data { get; set; }
        public string Name { get; set; } = string.Format("{UtcNow}-default.txt", DateTime.UtcNow);
    }
}
