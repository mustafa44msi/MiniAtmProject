using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MiniAtmProject
{
    internal static class Database
    {
        private static List<Account> Accounts { get; set; } = new()
        {
            new Account()
            {
                Name = "Mustafa",
                Pass = "1234",
                Balance = 100000.00m
            },
            new Account()
            {
                Name = "Kerim",
                Pass = "1234",
                Balance = 5000.00m
            },
            new Account()
            {
                Name = "Dede",
                Pass = "1234",
                Balance = 1000.00m
            }

        };

        public static List<Account> CreateOrGetDatabase()
        {
            return Accounts;
        }


    }
}
