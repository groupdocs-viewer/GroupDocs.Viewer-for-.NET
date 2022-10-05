namespace GroupDocs.Viewer.AspNetMvc.Core.Entities
{
    public class FileSystemEntry
    {
        public string FileName { get; private set; }

        public string FilePath { get; private set; }

        public bool IsDirectory { get; private set; }

        public long Size { get; private set; }

        private FileSystemEntry () { }

        public static FileSystemEntry Directory(string name, string path, long size) =>
            new FileSystemEntry
            {
                FileName = name,
                FilePath = path,
                IsDirectory = true,
                Size = size
            };

        public static FileSystemEntry File(string name, string path, long size) =>
            new FileSystemEntry
            {
                FileName = name,
                FilePath = path,
                IsDirectory = false,
                Size = size
            };
    }
}