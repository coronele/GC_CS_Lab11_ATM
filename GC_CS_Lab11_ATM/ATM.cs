using System;
using System.Collections.Generic;
using System.Text;
using static GC_CS_Lab11_ATM.MyMethods;

namespace GC_CS_Lab11_ATM
{
    class ATM
    {
        public static bool isLoggedIn = false;
        public static void Register(List<Account> regNewAccount, string username, string password)
        {
            regNewAccount.Add(new Account(username, password, 0));
        }

        public static void Register(List<Account> regNewAccount)
        {
            string username = GetUserInput("Please enter a username");
            string password = GetUserInput("Please enter a password");
            regNewAccount.Add(new Account(username, password, 0));
        }


        public static int Login(string enterUsername, string enterPassword, int enterCurrentAccount, List<Account> enterAccountList)
        {
            if (enterCurrentAccount != -1)
            {
                Console.WriteLine("There is someone already logged in");
                return enterCurrentAccount;
            }
            else
            {
                for (int i = 0; i < enterAccountList.Count; i++)
                {
                    if (enterUsername == enterAccountList[i].Name)
                    {
                        return i;
                    }
                }
                Console.WriteLine($"Username:{enterUsername} does not exist in this system.");
                return enterCurrentAccount;
            }
        }

        public static int Login(int enterCurrentAccount, List<Account> enterAccountList)
        {
            if (enterCurrentAccount != -1)
            {
                Console.WriteLine("There is someone already logged in");
                return enterCurrentAccount;
            }
            else
            {
                string enterUsername = GetUserInput("Please enter username");
                int tries = 0;
                for (int i = 0; i < enterAccountList.Count; i++)
                {
                    if (enterUsername == enterAccountList[i].Name)
                    {
                        do
                        {
                            tries++;
                            string enterPassword = GetUserInput("Please enter your password");
                            if (enterPassword == enterAccountList[i].Password)
                            {
                                return i;
                            }
                            else
                            {
                                SetOutputColor();
                                if (tries == 3)
                                {
                                    Console.WriteLine("Too many tries. Returning to main menu.");
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect password. Try again.");
                                }
                            }
                        }
                        while (tries < 3);
                        return -1;
                    }
                }
                Console.WriteLine($"Username:{enterUsername} does not exist in this system.");
                enterCurrentAccount = -1;
                return enterCurrentAccount;
            }
        }


        public static int Logout(int exitCurrentAccount)
        {
            if (exitCurrentAccount == -1)
            {
                return exitCurrentAccount;
            }
            else
            {
                SetOutputColor();
                Console.WriteLine("You have logged off the system.\n\n");
                exitCurrentAccount = -1;
                return exitCurrentAccount;
            }
        }

        public static int CheckBalance(int userCurrentAccount, List<Account> listOfAccounts)
        {
            if (userCurrentAccount == -1)
            {
                SetOutputColor();
                Console.WriteLine("User is not logged into account.");
                return userCurrentAccount;
            }
            else
            {
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    if (listOfAccounts[i].Name == listOfAccounts[userCurrentAccount].Name)
                    {
                        return listOfAccounts[i].Balance;
                    }
                }
                return userCurrentAccount;
            }
        }

        public static int Deposit(int userCurrentAccount, int amtDeposit, List<Account> listOfAccounts)
        {
            if (userCurrentAccount == -1)
            {
                SetOutputColor();
                Console.WriteLine("User is not logged into account.");
                return userCurrentAccount;
            }
            else
            {
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    if (listOfAccounts[i].Name == listOfAccounts[userCurrentAccount].Name)
                    {
                        return listOfAccounts[i].Balance += amtDeposit;
                    }
                }
                return userCurrentAccount;
            }
        }

        public static int Deposit(int userCurrentAccount, List<Account> listOfAccounts)
        {
            if (userCurrentAccount == -1)
            {
                SetOutputColor();
                Console.WriteLine("User is not logged into account.");
                return userCurrentAccount;
            }
            else
            {
                SetOutputColor();
                int amtDeposit = UserChoice("Please enter a deposit amount", "Not valid. Please enter whole dollar amounts", int.MaxValue);
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    if (listOfAccounts[i].Name == listOfAccounts[userCurrentAccount].Name)
                    {
                        return listOfAccounts[i].Balance += amtDeposit;
                    }
                }
                return userCurrentAccount;
            }
        }


        public static int Withdraw(int userCurrentAccount, int amtWithdraw, List<Account> listOfAccounts)
        {
            if (userCurrentAccount == -1)
            {
                SetOutputColor();
                Console.WriteLine("User is not logged into account.");
                return userCurrentAccount;
            }
            else
            {
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    if (listOfAccounts[i].Name == listOfAccounts[userCurrentAccount].Name)
                    {
                        if (listOfAccounts[userCurrentAccount].Balance < amtWithdraw)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Attempted account overdraw.  Withdraw of ${amtWithdraw} failed");
                            Console.ResetColor();
                            return -1;
                        }
                        else
                        {
                            return listOfAccounts[i].Balance -= amtWithdraw;
                        }
                    }
                }
                return userCurrentAccount;
            }
        }

        public static int Withdraw(int userCurrentAccount, List<Account> listOfAccounts)
        {
            if (userCurrentAccount == -1)
            {
                SetOutputColor();
                Console.WriteLine("User is not logged into account.");
                return userCurrentAccount;
            }
            else
            {
                int amtWithdraw = UserChoice("Please enter a withdrawl amount", "Not valid. Please enter whole dollar amounts", int.MaxValue);
                for (int i = 0; i < listOfAccounts.Count; i++)
                {
                    if (listOfAccounts[i].Name == listOfAccounts[userCurrentAccount].Name)
                    {
                        if (listOfAccounts[userCurrentAccount].Balance < amtWithdraw)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Attempted account overdraw.  Withdraw of ${amtWithdraw} failed");
                            SetOutputColor();
                            return -1;
                        }
                        else
                        {
                            return listOfAccounts[i].Balance -= amtWithdraw;
                        }
                    }
                }
                return userCurrentAccount;
            }
        }


        public static void BuildABank (List<Account> buildAccounts)
        {
            buildAccounts.Add(new Account("E_Coronel", "password1", 15400));
            buildAccounts.Add(new Account("M_Magoo", "password2", 252010));
            buildAccounts.Add(new Account("JohnRay", "password3", 3450));
            buildAccounts.Add(new Account("A_Earheart", "password4", 1247191));
            buildAccounts.Add(new Account("D_Adams", "password5", 42));
        }
    }
}