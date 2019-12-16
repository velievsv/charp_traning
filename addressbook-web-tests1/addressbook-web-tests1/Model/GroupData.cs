using System;
using System.Collections.Generic;
using System.Text;


namespace WebAddressbookTest
{
   public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string footer;

        public GroupData()
        {
        }


        public GroupData(string name)
            {
             this.name = name;
          
            }

        public GroupData(string header, string footer)
        {
            this.Header = header;
            this.footer = footer;
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
        public int  CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader = " + Header + "\nfooter = " + footer;
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
        public string id { get; set; }
    }
}
