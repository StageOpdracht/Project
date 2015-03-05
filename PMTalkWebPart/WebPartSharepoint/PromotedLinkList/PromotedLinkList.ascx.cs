using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
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
        private int c_intActiveButton = -1;
        private Package c_objPackage;
        
        //This constructor is used to hide tiles when clicked twice at same button
        public PromotedLinkList(int m_activeButton)
        {
            c_intActiveButton = m_activeButton;
        }

        //This constructor is used to show tiles when clicked on button
        public PromotedLinkList(NavSettings m_objNavSettings, int m_intActiveButton)
        {
            c_intActiveButton = m_intActiveButton;
            c_objPackage = m_objNavSettings.c_objPackList[c_intActiveButton];
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseViewID = "2";
        }

        protected override TileData[] GetTiles()
        {
            if (c_intActiveButton>=0)
            {
                TileData[] l_objData = new TileData[c_objPackage.c_obNavSettingList.Count];
                for (int i = 0; i < l_objData.Length; i++)
                {
                    NavSetting l_objNavSetting = c_objPackage.c_obNavSettingList[i];
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
            return new TileData[0];
        }

        protected override string ViewTitle
        {
            get { return "TestTiles"; }
        }
                                 
        
    }
}
