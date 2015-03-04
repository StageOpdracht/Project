using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;
using MainWebPart.Models;
using System.Xml.Serialization;
using System.IO;
using Microsoft.SharePoint.WebPartPages;
using System.Collections.Generic;
using MainWebPart.VisualWebPart1.Tiles;

namespace MainWebPart.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public class MainWebPartClass : System.Web.UI.WebControls.WebParts.WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/MainWebPart/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string c_strXmlPath = SPUtility.GetVersionedGenericSetupPath(@"TEMPLATE\XML\navSettings.xml", 15);
        private SPSite c_objSite;
        private SPWeb c_objWeb;
        public static NavSettings c_objNavSettings { get; private set; }
        public static int c_intActiveButton { get; set; }
        public List<TilesClass> c_objTilesList { get; set; }

        public MainWebPartClass()
        {
            c_objSite = SPContext.Current.Site;
            c_objWeb = c_objSite.OpenWeb();
            c_objWeb.AllowUnsafeUpdates = true;
            c_objTilesList = new List<TilesClass>();
            readFromFile();
        }

        private void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NavSettings));

            using (FileStream stream = File.OpenRead(c_strXmlPath))
            {
                c_objNavSettings = (NavSettings)serializer.Deserialize(stream);
            }
        }

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
            Button[] l_objButtons = new Button[c_objNavSettings.c_objPackList.Count];
            for (int i = 0; i < l_objButtons.Length; i++)
            {
                Package l_objPack = c_objNavSettings.c_objPackList[i];
                int num = 1 + i;
                l_objButtons[i] = new Button()
                {
                    Text = l_objPack.c_strName,
                    ID = "button " + i.ToString(),
                };

                l_objButtons[i].Click += new EventHandler(ButtonClick_event);

                Controls.Add(l_objButtons[i]);
                foreach(NavSetting setting in l_objPack.c_obNavSettingList)
                {
                    TilesClass tiles = new TilesClass(l_objPack)
                    {
                        ID = i.ToString(),
                        Title = l_objPack.c_strName,
                        Visible = true,     
                        
                    };
                    Controls.Add(tiles);
                    c_objTilesList.Add(tiles);
                }
            }
        }

        private void ButtonClick_event(object sender, EventArgs e)
        {
            foreach(TilesClass tile in c_objTilesList)
            {
                tile.Visible = false;
            }
            Button button = (Button)sender;
            string[] split = button.ID.Split(' ');
            int index = int.Parse(split[1]);
            TilesClass active = c_objTilesList[index];
            active.Visible = true;
        }
    }
}
