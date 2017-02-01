using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class URL
    {
        public string Name { get; set; }
        
        public string Href { get; }
        
        public bool isActive { get; set; }

        public URL(string Name, string Href)
        {
            this.Name = Name;
            this.Href = Href;
            isActive = false;
        }


    }
}
