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
        private CancellationTokenSource cancelToken = null;
        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the ints.
            this.Text = "Operation continue";
            cancelToken = new CancellationTokenSource();
        Task.Factory.StartNew(() =>
            {
                ProcessIntData();
                
            });
        }
        private void ProcessIntData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order.
            Thread.Sleep(2000);
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                                  where num % 3 == 0
                                  orderby num descending
                                  select num).ToArray();
                MessageBox.Show(string.Format("Found {0} numbers that match query!",
                modThreeIsZero.Count()));
            }
            catch(OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = ex.Message;
                });
            }
            
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
