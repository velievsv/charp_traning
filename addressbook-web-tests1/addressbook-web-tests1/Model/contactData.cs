﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressbookTest
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename;
        private string lastname ="";
        private string nickname = "";
        //  private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        //   private string bday;
        //   private string bmouth;
        //   private string byear;
        //   private string aday;
        //   private string amouth;
        //   private string ayear;
        //   private string new_group;
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";

        public ContactData (string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }

      //  public ContactData()
      //  {

      //  }

      

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
            return Firstname == other.Firstname && Middlename == other.Middlename;
        }

        public int CompareTo(ContactData other)
        {

            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (other.middlename == middlename)
            {
                if (other.firstname == firstname)
                {
                    return (firstname).CompareTo(other.firstname); ;
                }
            }
            return (middlename).CompareTo(other.middlename);
        }

        public override int GetHashCode()
        {
            return (Firstname + Middlename).GetHashCode();
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
       public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }
        public string Tittle
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
            public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public string Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }
        public string Work
        {
            get
            {
                return work;
            }

            set
            {
                work = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                email2 = value;
            }
        }

            public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                homepage = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }

            set
            {
                phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }
    }
}
