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
        private NavSettings _navSettings;

        public WebPart1()
        {
            _site = SPContext.Current.Site;
            _web = _site.OpenWeb();
            _web.AllowUnsafeUpdates = true;
            readFromFile("navSettings.xml");
            updateTileList();
        }

        private void updateTileList()
        {
            SPListItemCollection items = _web.Lists["TileList"].Items;

            SPListItem item;



            foreach (NavSetting i in _navSettings.NavSettingList)
            {
                bool times = true;
                foreach (SPListItem itm in items)
                {
                    if (!i.Name.Equals(itm.Name) && times)
                    {
                        item = items.Add();

                        item["Title"] = i.Name;
                        item["Description"] = i.Description;
                        //item["LinkLocation"] = i.Value;
                        //item["BackGroundImageLocation"] = i.Image;


                        item.Update();
                        times = false;
                    }
                }
                if(items.Count==0)
                {
                    item = items.Add();

                    item["Title"] = i.Name;
                    item["Description"] = i.Description;
                    //item["LinkLocation"] = i.Value;
                    //item["BackGroundImageLocation"] = i.Image;


                    item.Update();
                    times = false;
                }

            }
        }

        private void readFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NavSettings));

            using (FileStream stream = File.OpenRead(filename))
            {
                _navSettings = (NavSettings)serializer.Deserialize(stream);
                Console.WriteLine("noper");
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            SPList targetList = _web.Lists["TileList"];

            XsltListViewWebPart promotedListView = new XsltListViewWebPart();
            promotedListView.ListId = targetList.ID;
            promotedListView.ViewGuid = targetList.Views["Tiles"].ID.ToString("B").ToUpper();
            Controls.Add(promotedListView);
        }

    }
}
