using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace WebPartSharepoint.VisualWebPart1
{

    /* Copyright by Maxime Gaveele 2015 Jon Bille Productions */
    
    [ToolboxItemAttribute(false)]
    public class JonBille : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string fileContent;
        public JonBille ()
	{
        readFromFile("C:\\Development\\navSettings.xml");
	}

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Control list = new Control();

        }

        private void readFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

           
            using (FileStream stream = File.OpenRead(filename))
            {
                List<string> dezerializedList = (List<string>)serializer.Deserialize(stream);
            }
           
        }

        public void AddListsToWebPart()
        {
                 
        }
    }
}
