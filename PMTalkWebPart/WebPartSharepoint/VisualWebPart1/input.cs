using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPartSharepoint.VisualWebPart1
{
    class Input
    {
        private string name { get { return name; } set { this.name = name; } }
        private string image { get { return image; } set { this.image = image; } }
        private string description { get { return description; } set { this.description = description; } }


        public Input(string name, string image, string description)
        {
            this.name = name;
            this.image = image;
            this.description = description;
        }
       

    }
}
