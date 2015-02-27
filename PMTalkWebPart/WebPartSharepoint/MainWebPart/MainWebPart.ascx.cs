using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

namespace WebPartSharepoint.MainWebPart
{
    [ToolboxItemAttribute(false)]
    public partial class MainWebPart : TilesViewWebPart
    {
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string c_strXmlPath = SPUtility.GetVersionedGenericSetupPath(@"TEMPLATE\XML\navSettings.xml", 15);
        private SPSite c_objSite;
        private SPWeb c_objWeb;
        private NavSettings c_objNavSettings;

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MainWebPart()
        {
            c_objSite = SPContext.Current.Site;
            c_objWeb = c_objSite.OpenWeb();
            c_objWeb.AllowUnsafeUpdates = true;
            readFromFile();
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.BaseViewID = "2";
        }

        protected override TileData[] GetTiles()
        {
            TileData[] l_objData = new TileData[c_objNavSettings.c_objPackList.Count];
            for (int i = 0; i < l_objData.Length; i++)
            {
                Pack l_objPack = c_objNavSettings.c_objPackList[i];
                int num = 1 + i;
                l_objData[i] = new TileData
                {
                    ID = num,
                    Title = l_objPack.c_strName,
                    TileOrder = i
                };
            }
            return l_objData;
        }

        protected override string ViewTitle
        {
            get { return "Tile"; }
        }

        private void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NavSettings));

            using (FileStream stream = File.OpenRead(c_strXmlPath))
            {
                c_objNavSettings = (NavSettings)serializer.Deserialize(stream);
            }
        }
    }
}
