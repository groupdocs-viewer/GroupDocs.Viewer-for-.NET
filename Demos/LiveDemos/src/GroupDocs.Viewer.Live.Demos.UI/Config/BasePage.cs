using System;
using System.Data;
using System.Web;
using GroupDocs.Viewer.Live.Demos.UI.Config;

namespace GroupDocs.Viewer.Live.Demos.UI.Config
{
	public class BasePage : BaseRootPage
	{
		protected override void OnPreInit(EventArgs e)
		{

			base.OnPreInit(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (String.IsNullOrEmpty(Page.Title))
				{
					if (Resources != null)
					{
						Page.Title = Resources["ApplicationTitle"];
					}
				}
			}
			base.OnLoad(e);
		}

        protected string GetAsposeUnlockProduct(string fileName)
        {
            string asposeProduct = null;

            string ext = System.IO.Path.GetExtension(fileName).ToLower();

            if (ext == ".pdf")
            {
                asposeProduct = "PDF";
            }
            else if (ext == ".one")
            {
                asposeProduct = "Note";
            }
            else if (".doc .docx .dot .dotx .odt .ott".Contains(ext))
            {
                asposeProduct = "Words";
            }
            else if (".xls .xlsx .xlsm .xlsb .ods".Contains(ext))
            {
                asposeProduct = "Cells";
            }
            else if (".ppt .pptx .odp".Contains(ext))
            {
                asposeProduct = "Slides";
            }

            return asposeProduct;
        }
    }
}