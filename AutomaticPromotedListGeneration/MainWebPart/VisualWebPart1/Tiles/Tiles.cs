using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using MainWebPart.Models;

namespace MainWebPart.VisualWebPart1.Tiles
{
    [ToolboxItemAttribute(false)]
    public class TilesClass : TilesViewWebPart
    {
        private Package c_objPackage;
        protected override void CreateChildControls()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BaseViewID = "0";
        }

        public TilesClass(Package m_objPackage)
        {
            c_objPackage = m_objPackage;
        }

        protected override TileData[] GetTiles()
        {
            TileData[] l_objData = new TileData[c_objPackage.c_obNavSettingList.Count];
            for (int i = 0; i < 1; i++)
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

        protected override string ViewTitle
        {
            get { return this.Title; }
        }
    }
}
