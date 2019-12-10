using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WebAddressbookTest
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string details;

        public ContactData (string lastname, string firstname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public int CompareTo(ContactData other)
        {

            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (other.Firstname == Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Lastname + Firstname;
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return СleanUp(HomePhone) + СleanUp(MobilePhone) + СleanUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return СleanUp(Email) + СleanUp(Email2) + СleanUp(Email3).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string Details
       {  get
           {
                if (details != null)
                {
                    return details;
                }
                else
                {
                    return Firstname +" " + Lastname + "\r\n\r\n" + AddWords(HomePhone, "H: ") + AddWords(MobilePhone, "M: ") + AddWords(WorkPhone, "W: ") +"\r\n" + AddWords(Email, "") +
                            AddWords(Email2, "") + AddWords(Email3, "").Trim();
                }
            } 
            set
            {
                 details = value;
            }
        }

        private string AddWords(string phone, string prefix)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                return $"{prefix}{phone}\r\n";
            }
            return string.Empty;

        }   


        private string СleanUp(string phone)
        {
           if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]","") +"\r\n";
        }

        public string Firstname
        {
            get;set;
        }
        public string Middlename
        {
            get; set;
        }
       public string Lastname
        {
            get; set;
        }
        public string Nickname
        {
            get; set;
        }
        public string Tittle
        {
            get; set;
        }
        public string Company
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string HomePhone
        {
            get; set;
        }
        public string MobilePhone
        {
            get; set;
        }
        public string WorkPhone
        {
            get; set;
        }
        public string Fax
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string Email2
        {
            get; set;
        }

            public string Email3
        {
            get; set;
        }
        public string Homepage
        {
            get; set;
        }
        public string Address2
        {
            get; set;
        }
        public string Phone2
        {
            get; set;
        }
        public string Notes
        {
            get; set;

        }
        public string id { get; set; }

       
    }

}
