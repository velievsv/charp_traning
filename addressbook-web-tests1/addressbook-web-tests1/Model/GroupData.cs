using System;
using System.Collections.Generic;
using System.Text;


namespace WebAddressbookTest
{
   public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string footer;

            public GroupData(string name)
        {
            this.name = name;
          
        }

        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other,null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int GetHashCode()
        {
            return Name.GetHashCode();
        } 

        public GroupData(string header, string footer)
        {
            this.Header = header;
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
            get;set;
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
