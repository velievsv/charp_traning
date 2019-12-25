using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB;
using System.Configuration;

namespace WebAddressbookTest
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("addressbook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); }} 

    }
}
