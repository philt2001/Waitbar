using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Some possible help
//http://www.codeproject.com/Articles/58271/C-Windows-Form-is-Busy

namespace WaitbarTest1
{
    public partial class Waitbar : Form
    {
        public Waitbar(double newPercent, string newLabel = "")
        {
            InitializeComponent();
            this.Text = "Waitbar";

            label1.Text = newLabel;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000; //allow accuracy to 0.1%
            
            //Show the waitbar
            this.Show();

            //Now update the display
            Update(newPercent);
            this.Refresh(); //Update the displayed label
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        //Function to update wait bar
        public void Update(double newPercent)
        {
            progressBar1.Value = (int)(newPercent * 10);
            //this.Refresh(); //Refresh is automatic when changing the value
        }
    }
}
