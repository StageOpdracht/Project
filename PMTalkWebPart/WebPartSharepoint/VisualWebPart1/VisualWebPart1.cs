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


                item.Update();
            }
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
            Controls.Add(_listView);
        }

    }
}
