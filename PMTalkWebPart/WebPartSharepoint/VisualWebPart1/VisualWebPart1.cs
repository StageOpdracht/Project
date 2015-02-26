using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
<<<<<<< HEAD
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
=======
using System.Web.UI.WebControls.WebParts;
>>>>>>> 5a556c5f8036729f4ad8e9439a9da7fe0c89990a

namespace WebPartSharepoint.VisualWebPart1
{

    /* Copyright by Maxime Gaveele 2015 Jon Bille Productions */
    
    [ToolboxItemAttribute(false)]
    public class JonBille : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
<<<<<<< HEAD
        private string fileContent;
        public JonBille ()
	{
        readFromFile("C:\\Development\\navSettings.xml");
	}
=======
>>>>>>> 5a556c5f8036729f4ad8e9439a9da7fe0c89990a

        protected override void CreateChildControls()
        {
            
        }

<<<<<<< HEAD
        private void readFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

           
            using (FileStream stream = File.OpenRead(filename))
            {
                List<string> dezerializedList = (List<string>)serializer.Deserialize(stream);
            }
           
=======
        private void customEventHandler(object sender, WebPartEventArgs e)
        {
            
>>>>>>> 5a556c5f8036729f4ad8e9439a9da7fe0c89990a
        }

        private void readFromFile()
        {
        }

    }
}
