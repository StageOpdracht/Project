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
<<<<<<< HEAD
using Microsoft.SharePoint.Utilities;
=======
using System.Xml.Linq;
>>>>>>> 629053d886c9a7887b52e5546f75f3d0af819c80

namespace WebPartSharepoint.VisualWebPart1
{

    [ToolboxItemAttribute(false)]
    public class WebPart1 : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string fileContent;
<<<<<<< HEAD
        private SPSite _site;
        private SPWeb _web;
        private ListViewWebPart _listView;
        private List<Input> _listItems;

        public WebPart1()
        {
            _site = SPContext.Current.Site;
            _web = _site.OpenWeb();
            _listView = new ListViewWebPart();
            //readFromFile("navSettings.xml");
            updateTileList();
=======
        private XsltListViewWebPart listView;
        private List<navSettingsNavSetting> listItems;
        private navSettings navSettings;
        private Label lblTitle;

        public WebPart1()
        {
            listView = new XsltListViewWebPart();
<<<<<<< HEAD
            readFromFile("navSettings.xml");
=======
            //readFromFile("navSettings.xml");
            updateElementXml();
>>>>>>> 629053d886c9a7887b52e5546f75f3d0af819c80
            FillList();
>>>>>>> 14e96a03516b8ca11be8caae831146fa1a91a753
        }

        private void updateTileList()
        {
            SPListItemCollection items = _web.Lists["TileList"].Items;

            SPListItem item;

            foreach(Input i in _listItems)
            {
                item = items.Add();

                item["Title"] = i.Name;
                item["Description"] = i.Description;
                item["LinkLocation"] = "";
                item["BackGroundImageLocation"] = i.Image;

<<<<<<< HEAD

                item.Update();
            }
        }
        
        private void readFromFile(string filename)
=======
        Label myLabel = new Label();
        protected override void CreateChildControls()
>>>>>>> 14e96a03516b8ca11be8caae831146fa1a91a753
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
<<<<<<< HEAD

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Add(_listView);
        }

=======
>>>>>>> 14e96a03516b8ca11be8caae831146fa1a91a753
    }
}
        //moetn klassen nie me hfdletr?  :jva ma bon tis voor integriteit met XML kwn wa het belangrijkste is :p
