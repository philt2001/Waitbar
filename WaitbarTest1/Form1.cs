﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaitbarTest1
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

        //This button will launch the separte form
        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new waitbar
            WaitbarClass.Waitbar myWaitbar = new WaitbarClass.Waitbar(10, "This is my label it is really really really really really really really really really really really really really really v really really really really really really really really really really really really really reallyv really really long");
            
            System.Threading.Thread.Sleep(2000);
            myWaitbar.Update(50,"Changing label");
            for (int idx = 51; idx < 90; idx++)
            {
                System.Threading.Thread.Sleep(150);
                myWaitbar.Update(idx);
            }

            myWaitbar.Update(20.4,"A third label");
            System.Threading.Thread.Sleep(1000);

            myWaitbar.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
