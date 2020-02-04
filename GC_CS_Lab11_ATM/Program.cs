using System;
using System.Collections.Generic;
using static GC_CS_Lab11_ATM.MyMethods;

namespace GC_CS_Lab11_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            int loginStatus = -1;
            int mainMenuSelection = 0;
            List<string> mainMenu = new List<string>
            {
                "Register","Login"
            };
            
            // Build initial bank and account info
            List<Account> accountList = new List<Account> { };
            ATM.BuildABank(accountList);

            ShowTitle("ATM Program");
            do
            {
                DisplayMenu(mainMenu);
                mainMenuSelection = UserChoice($"Please select an option [1-{mainMenu.Count}]",$"That is not a valid option",mainMenu.Count);
                switch (mainMenuSelection)
                {
                    case 1:
                        ATM.Register(accountList);
                        break;
                    case 2:
                        loginStatus = ATM.Login(loginStatus,accountList);
                        if (loginStatus!=-1)
                        {
                            LoggedInOptions(loginStatus, accountList);
                        }
                        loginStatus = -1;
                        break;
                    default:
                        break;
                }
            }
            while (loginStatus == -1);
        }

        public static void DisplayMenu (List<string> menuOptions)
        {
            SetOutputColor();
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1})\t{menuOptions[i]}");
            }
        }

        public static void LoggedInOptions(int accountNum, List<Account> accounts)
        {
            int userMenuSelection;
            List<string> userOptions = new List<string>
            {
                "Deposit","Withdraw","Check Balance","Logout"
            };
            do
            {
                DisplayMenu(userOptions);
                userMenuSelection = UserChoice($"Please select an option [1-{userOptions.Count}]", $"That is not a valid option", userOptions.Count);
                switch (userMenuSelection)
                {
                    case 1:
                        SetOutputColor();
                        Console.WriteLine($"The new balance is ${ATM.Deposit(accountNum, accounts)}\n");
                        break;
                    case 2:
                        SetOutputColor();
                        Console.WriteLine(EvalWithdrawl(accountNum, accounts));
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"The balance for this account is ${ATM.CheckBalance(accountNum, accounts)}\n\n");
                        Console.ResetColor();
                        break;
                    case 4:
                        accountNum = ATM.Logout(accountNum);
                        break;
                    default:
                        break;
                }
            }
            while (accountNum != -1);

        }

        public static string EvalWithdrawl(int userAccountNum, List<Account> userAccounts)
        {
            int checkWithdrawl = ATM.Withdraw(userAccountNum, userAccounts);

            if (checkWithdrawl == -1)
            {
                return ("Returning to user menu.");
            }
            else
            {
                return ($"The new balance is ${userAccounts[userAccountNum].Balance}\n");
            }
        }
    }
}