﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebPartSharepoint.MainWebPart
{

    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [XmlType("navSettings")]
    public partial class NavSettings
    {
        [XmlElement("pack", typeof(Pack))]
        public List<Pack> c_objPackList { get; set; }
    }

    [XmlType("pack")]
    public partial class Pack
    {
        [XmlElement("pack", typeof(Pack))]
        public List<Pack> c_obNavSettingList { get; set; }

        [XmlAttributeAttribute("name")]
        public string c_strName { get; set; }
    }

    [XmlType("navSetting")]
    public partial class NavSetting
    {
        [XmlAttributeAttribute("name")]
        public string c_strName { get; set; }

        [XmlAttributeAttribute("image")]
        public string c_strImage { get; set; }

        [XmlAttributeAttribute("description")]
        public string c_strDescription { get; set; }

        [XmlTextAttribute()]
        public string c_strValue { get; set; }
    }
}