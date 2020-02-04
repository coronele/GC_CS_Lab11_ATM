using System;
using System.Collections.Generic;
using System.Text;

namespace GC_CS_Lab11_ATM
{
    class Account
    {
        private string name;
        private string password;
        private int balance;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public  Account() {}

        public Account(string acctUsername, string acctPassword, int acctBalance)
        // Adding account with all info including balance
        {
            name = acctUsername;
            password = acctPassword;
            balance = acctBalance;
        }

        public Account(string acctUsername, string acctPassword)
        // Adding with username and password.  Assumed starting balance at 0.
        {
            name = acctUsername;
            password = acctPassword;
            balance = 0;
        }

    }
}
