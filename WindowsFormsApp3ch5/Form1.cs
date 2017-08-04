using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp3ch5
{
    public partial class Form1 : Form
    {
        Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            int numberOfPeople = (int)numericUpDown1.Value;
            bool fancy = fancyOption.Checked;
            bool healthy = heathyOption.Checked;
            calculator = new Calculator(numberOfPeople, healthy, fancy);
            updateCost();
        }

        private void updateCost()
        {
            decimal cost = calculator.getTotalCost();
            textBox1.Text = cost.ToString("c");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            calculator.FancyDecoration = fancyOption.Checked;
            updateCost();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculator.NumberOfPeople = (int)numericUpDown1.Value;
            updateCost();
        }

        private void heathyOption_CheckedChanged(object sender, EventArgs e)
        {
            calculator.HealthyOption = heathyOption.Checked;
            updateCost();
        }
    }
}
