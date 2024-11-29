using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAtmProject
{
    internal class Account
    {
        private static int lastAccountID = 0;

        public Account()
        {
            AccountID = ++lastAccountID;
        }

        public string? Name { get; set; }
        public string? Pass { get; set; }
        public decimal Balance { get; set; }
        public int AccountID { get; private set; }

    }
}
