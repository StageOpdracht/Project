using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WebPartSharepoint.VisualWebPart1
{

    /* Copyright by Maxime Gaveele 2015 Jon Bille Productions */

    [ToolboxItemAttribute(false)]
    public class WebPart1 : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string fileContent;
        private XsltListViewWebPart listView;
        private List<Input> listItems;

        public WebPart1()
        {
            listView = new XsltListViewWebPart();
            //readFromFile("navSettings.xml");
            updateElementXml();
            FillList();
        }

        private void updateElementXml()
        {
            XDocument document = XDocument.Load("TileList/Elements.xml");
            XElement root = document.Root;

        }

        private void FillList()
        {
            SPSite site = SPContext.Current.Site;
            SPWeb web = site.OpenWeb();

            //Create the list in sharepoint
            listView.ID = "XsltListViewAppPromotedList";
            listView.ListUrl = "Lists/TileList";
            listView.IsIncluded = true;
            listView.NoDefaultStyle = "TRUE";
            listView.Title = "Images used in switcher";
            listView.PageType = PAGETYPE.PAGE_NORMALVIEW;
            listView.Default = "False";
            listView.ViewContentTypeId = "0x";
        }

        private void readFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));


            using (FileStream stream = File.OpenRead(filename))
            {
                List<string> dezerializedList = (List<string>)serializer.Deserialize(stream);
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Add(listView);
        }

    }
}
