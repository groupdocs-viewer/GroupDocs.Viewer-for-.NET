using GroupDocs.Viewer.Interfaces;
using System.IO;

namespace GroupDocs.Viewer.Forms.UI
{
    internal class MemoryPageStreamFactory : IPageStreamFactory
    {
        public Stream Stream { get; }

        public MemoryPageStreamFactory() : this(new MemoryStream()) { }

        public MemoryPageStreamFactory(Stream stream) => Stream = stream;

        public Stream CreatePageStream(int pageNumber)
        {
            Stream.Position = 0;
            Stream.SetLength(0);

            return Stream;
        }

        public void ReleasePageStream(int pageNumber, Stream pageStream)
        {
            //NOTE: the pageStream will be disposed by the consumer of this class
        }
    }
}
