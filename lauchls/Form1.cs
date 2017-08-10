using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lauchls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool started = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(!started)
            {
                start();
                started = true;
                button1.Text = "STOP LS!";
            }
            else
            {
                stop();
                started = false;
                button1.Text = "START LS!";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (started)
            {
                stop();
            }
        }

        void start()
        {
            string strCmdLine = "/C docker start lserver ";

            runCMD(strCmdLine);
        }

        void stop()
        {
            string cmd = "/C docker stop lserver";
            runCMD(cmd);
        }

        void runCMD(string s)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = s;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
