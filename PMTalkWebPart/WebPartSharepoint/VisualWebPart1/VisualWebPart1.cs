using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Web.UI.WebControls.WebParts;

namespace WebPartSharepoint.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public class VisualWebPart1 : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";

        protected override void CreateChildControls()
        {
            
        }

        private void customEventHandler(object sender, WebPartEventArgs e)
        {
            
        }

        private void readFromFile()
        {
        }

    }
}
