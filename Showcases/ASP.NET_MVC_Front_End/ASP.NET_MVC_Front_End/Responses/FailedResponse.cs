using System;

namespace MvcSample.Responses
{
    public class FailedResponse
    {
        //[DataMember(Name = "success")]
        public bool success { get; set; }

        //[DataMember(Name = "Reason")]
        public String Reason { get; set; }

        public FailedResponse()
        {
            success = false;
        }
    }

}
