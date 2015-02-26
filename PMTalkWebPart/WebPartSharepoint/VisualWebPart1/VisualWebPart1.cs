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
        private SPSite _site;
        private SPWeb _web;
       private navSettings _navSettings;
        private List<navSettings> _listItems;

        public WebPart1()
        {
            _site = SPContext.Current.Site;
            _web = _site.OpenWeb();
            readFromFile("navSettings.xml");
            updateTileList();
        }

        private void updateTileList()
        {
            SPListItemCollection items = _web.Lists["TileList"].Items;

            SPListItem item;

            foreach (navSettingsNavSetting i in _listItems)
            {
                item = items.Add();

                item["Title"] = i.name;
                item["Description"] = i.description;
                item["LinkLocation"] = i.Value;
                item["BackGroundImageLocation"] = i.image;


                item.Update();
            }
        }
        
        private void readFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(navSettings));

            using (FileStream stream = File.OpenRead(filename)) { 
                _navSettings = (navSettings)serializer.Deserialize(stream);
                _listItems.Add(_navSettings);
                Console.WriteLine("noper"); 
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            SPLimitedWebPartManager limitedWebPartManager = null;
            SPList targetList = _web.Lists["TileList"];

            XsltListViewWebPart promotedListView = new XsltListViewWebPart();
            promotedListView.ListId = targetList.ID;
            promotedListView.ViewGuid = targetList.Views["Tiles"].ID.ToString("B").ToUpper();
            Controls.Add(promotedListView);
        }

    }
}
