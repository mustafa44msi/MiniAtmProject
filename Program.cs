using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace MiniAtmProject
{
    internal class Program
    {
        public static Account? account { get; set; }

        public static void Main(string[] args)
        {
            var accounts = Database.CreateOrGetDatabase().FirstOrDefault();

            string selectionStart;
            while (true) 
            {
                GetStartMenu();
                selectionStart = Console.ReadLine()!;
                if (selectionStart == "1") 
                {
                    ATM.SignUp();
                }
                else if (selectionStart == "2")
                {
                    ATM.Login();
                    break;
                }
                else if (selectionStart == "3")
                {
                    ATM.Quit();
                }
                else
                {
                    Console.Clear();
                    Console.Write("Lütfen Geçerli Bir İşlem Giriniz.");
                    Thread.Sleep(1500);
                }

            }

            string selection;
            while (true)
            {
                GetMainMenu();
                selection = Console.ReadLine()!;
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        ATM.Withdraw(accounts);
                        Thread.Sleep(1500);
                        break;
                    case "2":
                        Console.Clear();
                        ATM.Deposit(accounts);
                        Thread.Sleep(1500);
                        break;
                    case "3":
                        Console.Clear();
                        ATM.ShowBalance(accounts);
                        Thread.Sleep(1500);
                        break;
                    case "4":
                        Console.Clear();
                        ATM.Transfer();
                        break;
                    case "5":
                        Console.Clear();
                        ATM.LogOut();
                        Main(args);
                        break;
                    case "6":
                        ATM.Quit();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Lütfen Geçerli Bir İşlem Giriniz.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        private static void GetMainMenu()
        {
            Console.Clear();
            Console.WriteLine(ATM.MainMenu);
            Console.Write("Ana Sayfa>");
        }

        public static void GetStartMenu()
        {
            Console.Clear();
            Console.WriteLine(ATM.StartMenu);
            Console.Write("Ana Sayfa>");
        }

    }

}