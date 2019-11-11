using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressbookTest
{
   public class GroupData
    {
        private string name;
        private string header;
        private string footer;

            public GroupData(string name)
        {
            this.name = name;
          
        }

        public GroupData(string header, string footer)
        {
            this.header = header;
            this.footer = footer;
        }
         public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }

        }
        public string Header
        {
            get;
            set;
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
