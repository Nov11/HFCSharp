using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        DispatcherTimer timer = new DispatcherTimer();
        Player[] players = new Player[3];
        Hound[] hounds = new Hound[4];
        Dictionary<string, int> hash = new Dictionary<string, int>() ;
        Random random = new Random();
        static int trackLength = 450;
        public Form1()
        {

            InitializeComponent();

            hash.Add("A", 0);
            hash.Add("B", 1);
            hash.Add("C", 2);

            players[0] = new Player { name = "A", cash = 100, radioButton = radioButton1, textBox = textBox1 };
            players[1] = new Player { name = "B", cash = 100, radioButton = radioButton2, textBox = textBox2 };
            players[2] = new Player { name = "C", cash = 100, radioButton = radioButton3, textBox = textBox3 };

            hounds[0] = new Hound { startPosition = 0, box = pictureBox2, trackLength = trackLength, random = random};
            hounds[1] = new Hound { startPosition = 0, box = pictureBox3, trackLength = trackLength, random = random };
            hounds[2] = new Hound { startPosition = 0, box = pictureBox4, trackLength = trackLength, random = random };
            hounds[3] = new Hound { startPosition = 0, box = pictureBox5, trackLength = trackLength, random = random };

            timer.IsEnabled = false;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            resetGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (hounds[i].run())
                {
                    string msg = "Hound :";
                    msg += i + 1;
                    msg += " wins!";
                    MessageBox.Show(msg);
                    timer.Stop();
                    dealWithBets(i);
                    resetGame();
                }
            }
        }

        private void dealWithBets(int winner)
        {
            for (int i = 0; i < 3; i++)
            {
                players[i].collect(winner);
            }
        }

        private void resetGame()
        {
            for (int i = 0; i < 4; i++)
            {
                hounds[i].prepare();
            }

            for (int i = 0; i < 3; i++)
            {
                players[i].updateLabel();
                players[i].clearBet();
            }

            enableButtons();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            disableButtons();
            timer.Start();
        }

        private void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
        }

        private void enableButtons()
        {

            button1.Enabled = true;
            button2.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int playerNum = hash[label3.Text];
            int money = (int)numericUpDown1.Value;
            int hound = (int)numericUpDown2.Value;
            hound -= 1;
            if (players[playerNum].bet != null) { MessageBox.Show("This player has already made bet."); return; }
            bool ret = players[playerNum].placeBet(money, hound);
            if (ret)
            {
                players[playerNum].updateLabel();
                players[playerNum].updateBets();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "A";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "B";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "C";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
