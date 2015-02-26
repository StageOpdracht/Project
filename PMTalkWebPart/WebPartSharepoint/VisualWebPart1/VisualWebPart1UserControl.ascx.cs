using Microsoft.SharePoint.WebPartPages;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebPartSharepoint.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {    
        public ListViewWebPart ListView {get;set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
