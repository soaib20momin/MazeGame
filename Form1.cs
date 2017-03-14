using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        private int _ticks;
        System.Media.SoundPlayer startSound = new System.Media.SoundPlayer(@"C:\Windows\Media\chord.wav");
        System.Media.SoundPlayer finishSound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            moveToStart();
        }

        private void wall_MouseEnter(object sender, EventArgs e)
        {
            moveToStart();
        }


        private void finish_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            finishSound.Play();
            DialogResult dr = MessageBox.Show("You won the game!! \nYou took " + _ticks + " seconds \n\n You want to try again ?" , "Congratulations!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
            if (dr == DialogResult.Yes)
            {
                _ticks = 0;
                labTimer.Text = string.Empty;
                timer1.Stop();
                timer1.Start();
                moveToStart();
            }
            else if (dr == DialogResult.No)
                Close();
        }

        private void moveToStart()
        {
            startSound.Play();
            Point startingPoint = panel1.Location;
            startingPoint.Offset(23, 46);
            Cursor.Position = PointToScreen(startingPoint);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            labTimer.Text = _ticks.ToString();
        }

        
    }
}
