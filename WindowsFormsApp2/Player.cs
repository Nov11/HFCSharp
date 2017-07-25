using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Player
    {
        public string name;
        public Bet bet;
        public int cash;


        public RadioButton radioButton;
        public TextBox textBox;

        public void updateLabel()
        {
            radioButton.Text = name + " has $" + cash;
        }

        public void updateBets()
        {
            string ret = bet.getBetInfo();
            textBox.Text = name + " bets " + ret;
        }

        public bool placeBet(int money, int hound)
        {
            if(money <= cash)
            {
                bet = new Bet(money, hound);
                cash -= money;
                return true;
            }

            return false;
        }

        public void clearBet() { bet = null; textBox.Text = name + " has not bet yet."; }

        public void collect(int winner)
        {
            if(bet == null) { return; }
            int ret = bet.payOut(winner);
            cash += ret;
        }
    }
}
