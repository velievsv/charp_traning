using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB.Mapping;


namespace WebAddressbookTest
{
    [Table(Name ="group_list")]
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

        [Column(Name ="group_name")]
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
        [Column(Name ="group_header")]
        public string Header
        {
            get;set;
        }
        [Column(Name ="group_footer")]
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
        [Column(Name ="group_id"), PrimaryKey, Identity]
        public string id { get; set; }
    }
}
