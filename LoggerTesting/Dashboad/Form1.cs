using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Dashboad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void click()
        {
            //Windows Ding.wav
            //SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Ding.wav");
            simpleSound.Play();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
           click();

            MessageBox.Show("alert");
        }
    }
}
