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
using Microsoft.SharePoint.Utilities;

namespace WebPartSharepoint.VisualWebPart1
{

    [ToolboxItemAttribute(false)]
    public class WebPart1 : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string fileContent;
        private XsltListViewWebPart listView;
        private List<navSettingsNavSetting> listItems;
        private navSettings navSettings;
        private Label lblTitle;

        public WebPart1()
        {
            listView = new XsltListViewWebPart();
            readFromFile("navSettings.xml");
            FillList();
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

        Label myLabel = new Label();
        protected override void CreateChildControls()
        {
            //Configure the Label
            myLabel.Width = new Unit(50, UnitType.Pixel);
     
            //Add it to the controls collection
            Controls.Add(myLabel);
        }


        private void readFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(navSettings));

            
            using (FileStream stream = File.OpenRead(filename))
            {
                navSettings = (navSettings)serializer.Deserialize(stream);
                myLabel.Text = navSettings.navSetting.name;
                Console.WriteLine("noper");
            }
        }
    }
}
        //moetn klassen nie me hfdletr?  :jva ma bon tis voor integriteit met XML kwn wa het belangrijkste is :p