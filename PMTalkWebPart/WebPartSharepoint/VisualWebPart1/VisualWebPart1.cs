﻿using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace WebPartSharepoint.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public class VisualWebPart1 : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/WebPartSharepoint/VisualWebPart1/VisualWebPart1UserControl.ascx";
        private string fileContent;
        private SPListCollection readListCollection;

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }

        private void readFromFile()
        {
            XmlTextReader reader = new XmlTextReader("");

            fileContent = reader.ReadContentAsString();
        }

        public void AddListsToWebPart()
        {
            SPSite site = SPContext.Current.Site;
            SPWeb web = site.OpenWeb();

            SPListCollection lists = web.Lists;
            foreach(var list in readListCollection)
            {
                
            }


        }
    }
}
