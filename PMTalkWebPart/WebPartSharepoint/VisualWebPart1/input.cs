using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

=======
<<<<<<< HEAD
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

        private string nameField;

        private string imageField;

        private string descriptionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }



//    [XmlRoot("navSettings", Namespace="", IsNullable=false)]
//    public class navSetting
//    {
        
//        [XmlElement("user")]
//        private string name { get { return name; } set { this.name = name; } }
        
//        [XmlElement("image")]
//        private string image { get { return image; } set { this.image = image; } }
        
//        [XmlElement("description")]
//        private string description { get { return description; } set { this.description = description; } }

//        public navSetting()
//        { 

//}
//        public navSetting(string name, string image, string description)
//        {
//            this.name = name;
//            this.image = image;
//            this.description = description;
//        }
       

//    }
}
=======
>>>>>>> 14e96a03516b8ca11be8caae831146fa1a91a753
namespace WebPartSharepoint.VisualWebPart1
{
    class input
    { /*
        private string naam; {get { return naam} ; set;}
        private string image;
        private string description;
       * */

    }
}
<<<<<<< HEAD
=======
>>>>>>> 629053d886c9a7887b52e5546f75f3d0af819c80
>>>>>>> 14e96a03516b8ca11be8caae831146fa1a91a753
