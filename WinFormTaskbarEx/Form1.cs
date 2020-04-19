using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTaskbarEx
{
    public partial class Form1 : Form
    {
        int timerCounter;
        int maxValue = 100;
        Timer PacingTimer = new Timer();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = maxValue;
            buttonQuit.Enabled = false;
            buttonRestart.Enabled = false;
            buttonStart.Enabled = true;

            // Wait for START button to be pressed to begin processing

            //PacingTimer.Interval = 1000 * 1; // time in msec 1 sec in this case
            //PacingTimer.Tick += new EventHandler(PacingTimer_Tick);
            //PacingTimer.Tag = "FunTimer";
            //PacingTimer.Start();
            //StopTimer(PacingTimer);
        }

        private void PacingTimer_Tick(object sender, EventArgs e)
        {
            if (timerCounter < maxValue)
            {
                timerCounter++;
                timerLabel.Text = @"Current tick count is: " + timerCounter.ToString();
                //Set the new value on track bar
                trackBar1.Value = timerCounter;
                //MessageBox.Show("Time Elapsed!", "Window will be closed");
                //this.Close();
            }
            else
            {
                // StopTimer(PacingTimer);
                PacingTimer.Stop();
                timerLabel.Text = @"Max Count of " + maxValue.ToString() + @" Reached by Timer " + PacingTimer.Tag + @", now disabled";
                this.Refresh();
                buttonQuit.Enabled = true;
                buttonRestart.Enabled = true;
                buttonStart.Enabled = false;
           
            }

        }

        private void InitializeTimer(Timer timerInstance)
        {
            timerCounter = 0;
            timerInstance.Interval = 1000 * 1; // time in msec 1 sec in this case
            //timerInstance.Tick += new EventHandler(PacingTimer_Tick);
            timerInstance.Tag = "FunTimer";
            timerInstance.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Move timer counter based on trackbar user setting
            timerCounter = trackBar1.Value;
        }

        private void Run(Timer timerInstance)
        {
            timerInstance.Tick += new EventHandler(PacingTimer_Tick);
        }

        private void ResetForm()
        {
            this.Dispose();
            Application.Restart();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            //DialogResult dialogBox = MessageBox.Show("Do you really want to exit?");
            //if (dialogBox == DialogResult.Yes)
            //{
            //    Application.ExitThread();
            //}
            //else if (dialogBox == DialogResult.No)
            //{
            //    ResetForm();
            //}

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            InitializeTimer(PacingTimer);
            Run(PacingTimer);
        }
    }
}

