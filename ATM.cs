using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAtmProject
{
    internal class ATM
    {
        public static Account? CurrentUser { get; set; }
        public static void Menus()
        {
            CurrentUser = Database.CreateOrGetDatabase().FirstOrDefault();
        }

        public static void SignUp()
        {
            var accounts = Database.CreateOrGetDatabase();

            Console.Clear();
            Console.Write("Lütfen İsminizi Girin: ");
            string Name = Console.ReadLine()!;
            Console.Write("Lütfen Şifrenizi Girin: ");
            string Pass = Console.ReadLine()!;
            Console.Write("Lütfen Bakiyenizi girin: ");
            decimal Balance = decimal.Parse(Console.ReadLine()!);

            var newUser = new Account();
            {
                newUser.Name = Name;
                newUser.Pass = Pass;
                newUser.Balance = Balance;
            }
            accounts.Add(newUser);
        }

        public static void Deposit(Account CurrentUser)
        {
            Console.Write("Yatırmak İstediğiniz Tutar: ");
            decimal yatirilacakTutar = decimal.Parse(Console.ReadLine()!);
            CurrentUser.Balance += yatirilacakTutar;
            Console.Clear();
            Console.WriteLine("Para Yatırma İşlemi Başarılı.");
            Thread.Sleep(1000);
            Console.Write($"Yeni Bakiyeniz: {CurrentUser.Balance}");
        }
        public static void Withdraw(Account CurrentUser)
        {
            Console.Write("Çekmek İstediğiniz Tutarı Girin: ");
            decimal cekilecekTutar = decimal.Parse(Console.ReadLine()!);
            if (cekilecekTutar > CurrentUser.Balance)
            {
                Console.Clear();
                Console.WriteLine("Yetersiz Bakiye");
            }
            else
            {
                CurrentUser.Balance -= cekilecekTutar;
                Console.Clear();
                Console.WriteLine("Para Çekme İşlemi Başarılı.");
                Thread.Sleep(1000);
                Console.Write($"Yeni Bakiyeniz: {CurrentUser.Balance}");
            }
        }
        public static void ShowBalance(Account CurrentUser)
        {
            Console.WriteLine($"Bakiyeniz: {CurrentUser.Balance}");
        }


        public static void Quit()
        {
            Console.Clear();
            Console.WriteLine("Çıkış Yapılıyor");
            Thread.Sleep(0500);
            Console.WriteLine(".");
            Thread.Sleep(0500);
            Console.WriteLine(".");
            Thread.Sleep(0500);
            Console.WriteLine(".");
            Thread.Sleep(0500);
            Console.Clear();
            Console.WriteLine("Görüşmek Üzere :(");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

    }
}
