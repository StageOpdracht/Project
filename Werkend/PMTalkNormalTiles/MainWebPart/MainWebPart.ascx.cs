using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using PMTalkNormalTiles.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

namespace PMTalkNormalTiles.MainWebPart
{
    [ToolboxItemAttribute(false)]
    public partial class MainWebPart : TilesViewWebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        private string c_strXmlPath = SPUtility.GetVersionedGenericSetupPath(@"TEMPLATE\XML\navSettings.xml", 15);
        private NavSettings c_objNavSettings;

        public MainWebPart()
        {
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override TileData[] GetTiles()
        {
            TileData[] l_objData = new TileData[c_objNavSettings.c_objNavSettingList.Count];
            for (int i = 0; i < l_objData.Length; i++)
            {
                NavSetting l_objNavSetting = c_objNavSettings.c_objNavSettingList[i];
                int num = 1 + i;
                l_objData[i] = new TileData
                {
                    ID = num,
                    LinkLocation = l_objNavSetting.c_strValue,
                    BackgroundImageLocation = l_objNavSetting.c_strImage,
                    Description = l_objNavSetting.c_strDescription,
                    Title = l_objNavSetting.c_strName,
                    TileOrder = i
                };
            }
            return l_objData;
        }

        protected override string ViewTitle
        {
            get { return "Tiles"; }
        }
    }
}
