using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParalelFor
{
    public partial class Form1 : Form
    {
        // New Form-level variable.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }
        private void ProcessFiles()
        {
            // Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // A simple source for demonstration purposes. Modify this path as necessary.
            String[] files = System.IO.Directory.GetFiles(@"D:\Desktop\Images", "*.jpg");
            String newDir = @"D:\Desktop\Modified";
            System.IO.Directory.CreateDirectory(newDir);

            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            // Be sure to add a reference to System.Drawing.dll.
            Parallel.ForEach(files, (currentFile) =>
            {
                // The more computational work you do here, the greater 
                // the speedup compared to a sequential foreach loop.
                try
                {
                    String filename = System.IO.Path.GetFileName(currentFile);
                    var bitmap = new Bitmap(currentFile);
                    Thread.Sleep(3000);

                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDir, filename));

                    this.Invoke((Action)delegate
                    {
                        this.Text = Thread.CurrentThread.ManagedThreadId + " Thread";
                    });

                    this.Invoke((Action)delegate
                    {
                        this.Text = "Done";
                    });
                }
                catch(OperationCanceledException ex)
                {
                    this.Invoke((Action)delegate
                    {
                        this.Text = ex.Message;
                    });
                }
                

                //close lambda expression and method invocation
            });


            // Keep the console window open in debug mode.
            MessageBox.Show("Processing complete. Press any key to exit.");
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
