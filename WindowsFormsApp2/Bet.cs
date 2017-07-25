using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp2
{
    class Bet
    {
        public int amount;
        public int hound;

        public Bet(int money, int houndNumber)
        {
            amount = money;
            hound = houndNumber;
        }

        public int payOut(int winnerHound)
        {
            if(winnerHound== hound)
            {
                return amount * 2;
            }

            return -1 * amount;
        }

        public string getBetInfo()
        {
            int n = hound + 1;
            return "$" + amount + " on hound: " + n;
        }
    }
}
