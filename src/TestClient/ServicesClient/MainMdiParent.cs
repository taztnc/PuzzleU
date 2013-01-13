using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServicesClient
{
    public partial class MainMdiParent : Form
    {
        private int childFormNumber = 0;

        public MainMdiParent()
        {
            InitializeComponent();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMDIChild(new FormUserName());
        }

        private void albumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMDIChild(new FormAlbums());
        }

        private void puzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMDIChild(new FormPuzzles());
        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMDIChild(new FormImages());
        }

        private void OpenMDIChild(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void userMetaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMDIChild(new FormUserMetaData());
        }

    }
}
