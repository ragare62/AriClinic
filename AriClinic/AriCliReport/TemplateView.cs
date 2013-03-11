using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliReport
{
    public class TemplateView
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
