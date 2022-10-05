namespace GroupDocs.Viewer.AspNetWebForms.Core.Entities
{
    public class PageResource
    {
        public PageResource(string resourceName, byte[] data)
        {
            ResourceName = resourceName;
            Data = data;
        }

        public string ResourceName { get; }

        public byte[] Data { get; }
    }
}