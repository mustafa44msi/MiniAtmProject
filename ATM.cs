using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
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
        public static void Login()
        {
            var accounts = Database.CreateOrGetDatabase();
            Console.Clear();
            string Name;
            string Pass;
            int maxAttemps = 3;
            Account? User = null;

            while (true)
            {
                Console.Write("Lütfen İsminizi Girin: ");
                Name = Console.ReadLine()!;
                User = accounts.FirstOrDefault(account => account.Name?.ToLower() == Name.ToLower());
                if (User != null)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Eksik veya Hatalı Bir İsim Girdiniz. Lütfen Tekrar Deneyiniz.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }

            for (int attemp = 1; attemp <= maxAttemps; attemp++)
            {
                Console.Write("Lütfen Şifrenizi Girin: ");
                Pass = Console.ReadLine()!;
                if (User.Pass == Pass)
                {
                    CurrentUser = User;
                    break;
                }
                else if (attemp == maxAttemps)
                {
                    Console.Clear();
                    Console.WriteLine("Tüm giriş haklarınızı tükettiniz. Ana Menüye Dönülüyor.");
                    Thread.Sleep(1000);
                    Program.Main(new string[] { });
                }
                else
                {
                    Console.Clear();
                    Console.Write($"Eksik veya Hatalı Bir Şifre Girdiniz. {maxAttemps - attemp} hakkınız kaldı. Lütfen Tekrar Deneyiniz.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }


            }
        }

        public static void LogOut()
        {
            CurrentUser = null;
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

        public static string MainMenu => $@"Merhaba {CurrentUser?.AccountID} - {CurrentUser?.Name} Anlık Olarak {CurrentUser?.Balance} TL Bakiyen var.
Lütfen Yapmak İstediğiniz İşlemi Seçiniz:

1-Para Çek
2-Para Yatır
3-Bakiye Göster
4-Ana Menüye Dön
5-Çıkış Yap
";

        public static string StartMenu => @"Merhaba Lütfen Yapmak İstediğiniz İşlemi Seçiniz:

1-Kayıt Ol
2-Giriş Yap
3-Çıkış Yap
";

    }
}
