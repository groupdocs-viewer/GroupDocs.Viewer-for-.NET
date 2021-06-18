using Huygens;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GroupDocs.Viewer.WebForms.Test
{
    [TestFixture]
    public class ViewerTest
    {
        [Test]
        public void ViewStatusTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {
                var request = new SerialisableRequest
                {
                    Method = "GET",
                    RequestUri = "/viewer",  
                    Content = null
                };
                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public void FileTreeStatusCodeTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {
                var request = new SerialisableRequest
                {
                    Method = "POST",
                    RequestUri = "/loadfiletree",
                    Content = null,
                    Headers = new Dictionary<string, string>{
                        { "Content-Type", "application/json"}
                    }
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }
    }
}
