namespace GroupDocs.Viewer.AspNetMvc.Core.Entities
{
    public class FileCredentials
    {
        public string FilePath { get; }
        public string FileType { get; }
        public string Password { get; }

        public FileCredentials(string filePath, string fileType, string password)
        {
            FilePath = filePath;
            FileType = fileType;
            Password = password;
        }
    }
}