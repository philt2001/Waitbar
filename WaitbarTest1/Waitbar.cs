﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Some possible help
//http://www.codeproject.com/Articles/58271/C-Windows-Form-is-Busy

namespace WaitbarClass
{
    public partial class Waitbar : Form
    {
        Form form = new Form();
        Label label1 = new Label();
        ProgressBar progressBar1 = new ProgressBar();
        Button cancelButton1 = new Button();

        //Flag to check if the form has been closed
        bool closedFlag;
        bool cancelButtonClickedFlag;
        String cancelButtonUpdateText = "Cancelled";
        
        public Waitbar(double newPercent, string newLabel = "", bool cancelButtonFlag = false)
        {
            //Set the size and add the components
            label1.SetBounds(12, 9, 335, 39);
            progressBar1.SetBounds(12, 60, 335, 23);
            cancelButton1.SetBounds( 275, 100, 75, 23 );

            form.ClientSize = new Size(375, 138);
            form.Controls.AddRange(new Control[] { label1, progressBar1, cancelButton1 });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            //Detect if form has been closed
            form.FormClosing += new FormClosingEventHandler(this.FormClosing_callback);
            closedFlag = false;

            //Set the waitbar settings
            form.Text = "Waitbar";

            label1.Text = newLabel;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000; //allow accuracy to 0.1%

            //Cancel button
            cancelButtonClickedFlag = false;
            if (cancelButtonFlag)
            {
                cancelButton1.Text = "Cancel";
                cancelButton1.Visible = true;
                cancelButton1.Click += new EventHandler(CancelButton_click);
            }
            else
            {
                cancelButton1.Visible = false;
            }

            //Show the waitbar
            form.Show();

            //Now update the display
            Update(newPercent);
            form.Refresh(); //Update the displayed label
        }

        //Function to update wait bar
        public void Update(double newPercent, string newLabel = "")
        {
            //Change the label?
            if (newLabel != String.Empty)
            {
                label1.Text = newLabel;
                this.Refresh();
                //Application.DoEvents(); //to force an update
            }

            progressBar1.Value = (int)(newPercent * 10);
            //this.Refresh(); //Refresh is automatic when changing the value
            Application.DoEvents();
        }

        //Close function
        //Use the new keyword to hide the inherited form close method
        new public void Close()
        {
            form.Close();
            this.Dispose(); //this might not be necessary
        }

        new public void Refresh()
        {
            form.Refresh();
            progressBar1.Refresh();
        }

        //Handle the form being closed
        private void FormClosing_callback(object sender, FormClosingEventArgs e)
        {
            closedFlag = true;
            int a = 0;
        }

        //Function to check if the form was closed (for whatever reason)
        public bool CheckClosed()
        {
            return closedFlag;
        }

        //Cancel button callback
        private void CancelButton_click(object sender, EventArgs e)
        {
            cancelButtonClickedFlag = true;
            //Need update method for this text
            label1.Text = cancelButtonUpdateText;
        }

        //Function to check if the cancel button was clicked
        public bool CheckCancel()
        {
            return cancelButtonClickedFlag;
        }
    }
}
