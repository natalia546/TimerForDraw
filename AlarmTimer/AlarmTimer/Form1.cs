using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AlarmTimer
{
    public partial class Form1 : Form
    {
        Timer timer01 = new Timer();
            SoundPlayer sp = new SoundPlayer(@"D:\Мои проекты\GitHubRepositiry\TimerForDraw\AlarmTimer\alarm.wav");
            bool b = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            timer01.Interval = 1000;
            timer01.Tick += new EventHandler(timer1_Tick);
            timer01.Start();
        }


        string TimerTime;
        DateTime TimeStart;
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                label2.Text = "00:00";
                TimerTime= maskedTextBox1.Text;
                TimeStart = DateTime.Now;
                timer2.Start();
                maskedTextBox1.Visible = false;
                button1.Text = "Убрать будильник";
                b = true;
            }
  else if (b == true)
            {
                label2.Text = "00:00";
                timer2.Stop();
                maskedTextBox1.Visible = true;
                button1.Text = "Завести будильник";
                b = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (TimerTime == label2.Text)
            {
                button2.Enabled = true;
                sp.Play();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                label1.Text = DateTime.Now.Hour.ToString("00") + ":" +
                    DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            var t = (DateTime.Now - TimeStart);
            label2.Text =t.Minutes.ToString("00") + ":" + t.Seconds.ToString("00"); ;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Stop();
          button2.Enabled = false;
          maskedTextBox1.Visible = true;
          button1.Text = "Завести будильник";
          b = false;
        }
    }
}
