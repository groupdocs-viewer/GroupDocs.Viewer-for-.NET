namespace MvcSample.Models
{
    public class RotatePageParameters
    {
        public string Path { get; set; }
        public int PageNumber { get; set; }
        public int RotationAmount { get; set; }
        public string InstanceIdToken { get; set; }
        public string Callback { get; set; }
    }

    public class RotatePageResponse
    {
        public RotatePageResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public int resultAngle { get; set; }
    }
}