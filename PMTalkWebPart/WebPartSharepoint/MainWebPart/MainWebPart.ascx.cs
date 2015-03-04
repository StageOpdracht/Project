using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using WebPartSharepoint.Models;

namespace WebPartSharepoint.MainWebPart
{
    [ToolboxItemAttribute(false)]
    public partial class MainWebPart : WebPart
    {
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string c_strXmlPath = SPUtility.GetVersionedGenericSetupPath(@"TEMPLATE\XML\navSettings.xml", 15);
        private SPSite c_objSite;
        private SPWeb c_objWeb;
        public static NavSettings c_objNavSettings { get; private set; }
        public static int c_intActiveButton { get; set; }

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
            base.CreateChildControls();
            Button[] l_objData = new Button[c_objNavSettings.c_objPackList.Count];
            for (int i = 0; i < l_objData.Length; i++)
            {
                Package l_objPack = c_objNavSettings.c_objPackList[i];
                int num = 1 + i;
                l_objData[i] = new Button()
                {
                    Text = l_objPack.c_strName,
                };

                l_objData[i].Click += new EventHandler(ButtonClick_event);

                Controls.Add(l_objData[i]);
            }

            UserControl promotedLinks 
        }

        private void ButtonClick_event(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
