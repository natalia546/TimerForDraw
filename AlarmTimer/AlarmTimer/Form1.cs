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
        SoundPlayer sp0 = new SoundPlayer(Properties.Resources.alarm0);//(@"D:\Мои проекты\GitHubRepositiry\TimerForDraw\AlarmTimer\alarm0.wav");
        SoundPlayer sp1 = new SoundPlayer(Properties.Resources.alarm1); //(@"D:\Мои проекты\GitHubRepositiry\TimerForDraw\AlarmTimer\alarm1.wav");
        bool b = false;
        public Form1()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();
              Form_Path.AddEllipse(45, 90, 150,150);
             Form_Path.AddEllipse(16, 80, 50, 50);
             Form_Path.AddEllipse(176, 80, 50, 50);
               Region Form_Region = new Region(Form_Path);
              this.Region = Form_Region;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();

            Button_Path.AddEllipse(2, 2, 52, 52);
            Region Button_Region = new Region(Button_Path);
            this.button2.Region = Button_Region;
            button2.BackColor = Color.Red;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           timer01.Interval = 1000;
            
        }

        int tSec;
        int tMin;
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                label2.Text = maskedTextBox1.Text;
               
                tMin = Convert.ToInt32(maskedTextBox1.Text.Substring(0, 2));
                tSec = Convert.ToInt32(maskedTextBox1.Text.Substring(3));
                tMin = tMin > 59 ? 59 :tMin;
                tSec = tSec > 59 ? 59 : tSec;
                maskedTextBox1.Visible = false;
                button1.Text = "Убрать будильник";
                b = true;
                timer01.Tick += new EventHandler(timer1_Tick);
                timer01.Start();
            }
  else if (b == true)
            {
                label2.Text = "00:00";
                maskedTextBox1.Visible = true;
                button1.Text = "Завести будильник";
                b = false;
                timer01.Stop();
                timer01.Tick -= timer1_Tick;
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tSec > 0)
            {
                tSec--;
            }
            else
            {
                if (tMin != 0)
                {
                    tMin--;
                    tSec = 59;
                }
                
            }
            label2.Text = tMin.ToString("00") + ":" +tSec.ToString("00");
            if (tMin == 0)
            {
                if(tSec==10||tSec==5 )
                {
                    sp1.Play();
                }
                if (tSec == 0)
                {
                    timer01.Stop();
                    timer01.Tick -= timer1_Tick;
                    sp0.Play();
                    label2.Text = "00:00";
                    maskedTextBox1.Visible = true;
                    button1.Text = "Завести будильник";
                    b = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
