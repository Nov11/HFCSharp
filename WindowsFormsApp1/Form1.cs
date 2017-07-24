using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len = generate(textBox1.Text, (int)numericUpDown1.Value);
            MessageBox.Show("The msg len is " + len);
        }

        public static int generate(string str, int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                result += str + "\n";
            }
            MessageBox.Show(result);
            return result.Length;
        }
    }
}
