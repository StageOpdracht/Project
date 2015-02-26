using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebPartSharepoint.VisualWebPart1
{

    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [XmlType("navSettings")]
    public partial class NavSettings
    {
        [XmlElement("navSetting", typeof(NavSetting))]           
        public List<NavSetting> NavSettingList { get; set; }
    }


    [XmlType("navSetting")]
    public partial class NavSetting
    {
        [XmlAttributeAttribute("name")]
        public string Name { get; set; }

        [XmlAttributeAttribute("image")]
        public string Image { get; set; }

        [XmlAttributeAttribute("description")]
        public string Description { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }
    }
}