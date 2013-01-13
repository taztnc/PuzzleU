using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServicesClient.PuzzleUService;

namespace ServicesClient
{
    public partial class FormUserMetaData : Form
    {
        public FormUserMetaData()
        {
            InitializeComponent();
        }

        private void buttonGetUserMetaData_Click(object sender, EventArgs e)
        {
            var proxy = new PuzzleUService.PuzzleUServiceClient();
            UserData userData = null;
            String errorMessage = null;
            if (!proxy.GetUserData(out userData, out errorMessage, int.Parse(textBoxUserId.Text)))
            {
                MessageBox.Show(errorMessage);
            }

            PupulateTreeView(userData);
        }

        private void PupulateTreeView(UserData userData)
        {
            TreeNode tn = treeViewUser.Nodes.Add("Name","Name:" + userData.Name);
            tn.Nodes.Add("ID", userData.ID.ToString());

            if (userData.Albums.Length == 0)
            {
                return;
            }
            TreeNode albumsTn = tn.Nodes.Add("Albums");
            foreach (var albumData in userData.Albums)
            {
                TreeNode singleAlbumTn = albumsTn.Nodes.Add("Name","Name:"+albumData.Name);
                singleAlbumTn.Nodes.Add("ID", "ID:"+albumData.ID.ToString());
                if (albumData.Images.Length == 0)
                {
                    continue;
                }
                TreeNode imagesTn = singleAlbumTn.Nodes.Add("Images");
                foreach (var imageData in albumData.Images)
                {
                    TreeNode singleImageTn = imagesTn.Nodes.Add("ID", "ID:"+imageData.ID.ToString());
                    singleImageTn.Nodes.Add("Width", "Width:" + imageData.Width.ToString());
                    singleImageTn.Nodes.Add("Height", "Height:" + imageData.Height.ToString());
                    singleImageTn.Nodes.Add("URL", "URL:" + imageData.URL.ToString());
                }
            }
        }
    }
}
