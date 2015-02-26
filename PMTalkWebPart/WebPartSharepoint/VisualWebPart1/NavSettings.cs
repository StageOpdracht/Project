using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebPartSharepoint.VisualWebPart1
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class navSettings
    {

        private navSettingsNavSetting navSettingField;

        /// <remarks/>
        public navSettingsNavSetting navSetting
        {
            get
            {
                return this.navSettingField;
            }
            set
            {
                this.navSettingField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class navSettingsNavSetting
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { get; private set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string image { get; private set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { get; private set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; private set; }
    }
}

