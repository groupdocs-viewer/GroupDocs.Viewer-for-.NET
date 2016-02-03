using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupDocs.Viewer.Model.BusinessObjects

{
    public class HtmlInfo
    {
        private String _HtmlContent;

        public String HtmlContent
        {
            get { return _HtmlContent; }
            set { _HtmlContent = value; }
        }
        private int _PageNmber;

        public int PageNmber
        {
            get { return _PageNmber; }
            set { _PageNmber = value; }
        }
    }
    public class ImageInfo
    {
        private String _ImageUrl;

        public String ImageUrl
        {
            get { return _ImageUrl; }
            set { _ImageUrl = value; }
        }
        private int _PageNmber;

        public int PageNmber
        {
            get { return _PageNmber; }
            set { _PageNmber = value; }
        }
        private String _HtmlContent;

        public String HtmlContent
        {
            get { return _HtmlContent; }
            set { _HtmlContent = value; }
        }
    }
}
