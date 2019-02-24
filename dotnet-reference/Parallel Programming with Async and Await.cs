using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParalelFor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnProcessImages_Click(object sender, EventArgs e)
        {
            this.Text = "Working";
            this.Text =await DoWorkAsync();
        }
        //private string DoWork()
        //{
        //    Thread.Sleep(10000);
        //    return "Done with work!";
        //}

        private async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work!";
            });
        }

        private async Task MethodReturningVoidAsync()
        {
            await Task.Run(() => { /* Do some work here... */
                Thread.Sleep(4000);
                MessageBox.Show("Done!");
            });
        }

        private async void btnMutiAwaits_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { Thread.Sleep(2000); }); MessageBox.Show("Done with first task!");
            await Task.Run(() => { Thread.Sleep(2000); }); MessageBox.Show("Done with second task!");
            await Task.Run(() => { Thread.Sleep(2000); }); MessageBox.Show("Done with third task!");

        }
    }
}
