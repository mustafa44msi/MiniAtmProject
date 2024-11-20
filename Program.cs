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

        private static void Main(string[] args)
        {
            var accounts = Database.CreateOrGetDatabase();

           

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

            Console.Clear();
            Console.Write("Lütfen isminizi Girin: ");   
            string Name;

            while (true)
            {

               Name = Console.ReadLine()!;
                account = accounts.FirstOrDefault(account => account.Name?.ToLower() == Name.ToLower());
                if (account != null) 
                { 
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Eksik veya Hatalı Bir İsim Girdiniz. Lütfen Tekrar Deneyiniz.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.Write("Lütfen İsminizi Girin: ");
                }
            }

            Console.Write("Lütfen Şifrenizi Girin: ");
            string Pass;

            while (true)
            {
                Pass = Console.ReadLine()!;
                if (account.Pass == Pass) 
                { 
                    break; 
                }
                else
                {
                    Console.Clear();
                    Console.Write("Eksik veya Hatalı Bir Şifre Girdiniz. Lütfen Tekrar Deneyiniz.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.Write("Lütfen Şifrenizi Girin: ");
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
                        ATM.Withdraw(account);
                        Thread.Sleep(1500);
                        break;
                    case "2":
                        Console.Clear();
                        ATM.Deposit(account);
                        Thread.Sleep(1500);
                        break;
                    case "3":
                        Console.Clear();
                        ATM.ShowBalance(account);
                        Thread.Sleep(1500);
                        break;
                    case "4":
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
            Console.WriteLine(MainMenu);
            Console.Write("Ana Sayfa>");
        }

        private static void GetStartMenu()
        {
            Console.Clear();
            Console.WriteLine(StartMenu);
            Console.Write("Ana Sayfa>");
        }

        private static string MainMenu => $@"Merhaba {account?.AccountID} - {account?.Name} Anlık Olarak {account?.Balance} TL Bakiyen var.
Lütfen Yapmak İstediğiniz İşlemi Seçiniz:

1-Para Çek
2-Para Yatır
3-Bakiye Göster
4-Çıkış Yap
";

        private static string StartMenu => @"Merhaba Lütfen Yapmak İstediğiniz İşlemi Seçiniz:

1-Kayıt Ol
2-Giriş Yap
3-Çıkış Yap
";
    }

}