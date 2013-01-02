using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using PuzzleUServices;
using System.Threading;

namespace HostForm
{
    public partial class HostForm : Form
    {
        private ServiceHost host;


        public HostForm()
        {
            InitializeComponent();
            host = null;

            try
            {
                PuzzleUService service = new PuzzleUService();
                host = new ServiceHost(service, new Uri[] { });
                host.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: {0}", ex.Message));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (host == null)
                return;
            host.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "Closing host, please wait...";
            this.Close();
        }
    }
}
