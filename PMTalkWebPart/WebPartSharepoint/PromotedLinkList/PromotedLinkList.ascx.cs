using Microsoft.SharePoint.WebPartPages;
using System;
using System.ComponentModel;
using WebPartSharepoint.Models;

namespace WebPartSharepoint.MainWebPart.PromotedLinkList
{
    [ToolboxItemAttribute(false)]
    public partial class PromotedLinkList : TilesViewWebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        private NavSettings c_objNavSettings;
        private int c_intActiveButton = 0;

        public PromotedLinkList()
        {
            c_objNavSettings = MainWebPart.c_objNavSettings;
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
            TileData[] l_objData = new TileData[c_objNavSettings.c_objPackList[c_intActiveButton].c_obNavSettingList.Count];
            for (int i = 0; i < l_objData.Length; i++)
            {
                NavSetting l_objNavSetting = c_objNavSettings.c_objPackList[1].c_obNavSettingList[i];
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
            get { return "TestTiles"; }
        }
    }
}
