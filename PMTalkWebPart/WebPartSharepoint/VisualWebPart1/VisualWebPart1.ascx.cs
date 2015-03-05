using Microsoft.SharePoint.Utilities;
using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using WebPartSharepoint.MainWebPart.PromotedLinkList;
using WebPartSharepoint.Models;

namespace WebPartSharepoint.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        private string c_strXmlPath = SPUtility.GetVersionedGenericSetupPath(@"TEMPLATE\XML\navSettings.xml", 15);
        private NavSettings c_objNavSettings;
        private int c_intActiveButton;

        public VisualWebPart1()
        {
            readFromFile();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Button button;
            int counter = 0;
            foreach(Package iPackage in c_objNavSettings.c_objPackList)
            {
                button = new Button()
                {
                    Text = iPackage.c_strName,
                    ID = "Button " + counter,
                };
                button.Click += new EventHandler(OnClickHandler);
                Controls.Add(button);
                counter++;
            }
            Controls.Add(new PromotedLinkList(-1));
        }

        private void OnClickHandler(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
            Button l_objButton = (Button)sender;

            string[] l_strSplit = l_objButton.ID.Split(' ');
            int l_intIndex = int.Parse(l_strSplit[1]);

            if(l_intIndex == c_intActiveButton)
            {
                Controls.Add(new PromotedLinkList(-1));
            }
            else
            {
                c_intActiveButton = l_intIndex;
                Controls.Add(new PromotedLinkList(c_objNavSettings, c_intActiveButton));
            }
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
