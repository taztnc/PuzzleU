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
    public partial class FormAlbums : Form
    {
        public FormAlbums()
        {
            InitializeComponent();
            UpdateUI();
        }        

        private void UpdateUI()
        {
            listBoxAlbums.Items.Clear();

            var proxy = new PuzzleUService.PuzzleUServiceClient();

            int userId;
            if (!int.TryParse(textBoxUserAlbumsUserID.Text, out userId))
            {
               listBoxAlbums.Items.Add("Please select user ID");
               return;
            }

            int[] albumIds = null;
            string errorString = string.Empty;

            if (!proxy.GetAlbumIDs(out albumIds, out errorString, userId))
            {
                listBoxAlbums.Items.Add(errorString);   
                return;
            }

            PuzzleUService.AlbumData[] albumsData = null;
            if (!proxy.GetAlbumsData(out albumsData, out errorString, userId))
            {
                listBoxAlbums.Items.Add(errorString);
                return;
            }

            foreach ( PuzzleUService.AlbumData albumData in albumsData)
            {
                 string listItem = string.Format("AlbumName: {0}   AlbumId: {1}", albumData.Name, albumData.ID.ToString());
                 listBoxAlbums.Items.Add(listItem);
            }                  
        }

        private void buttonCreateAlbum_Click(object sender, EventArgs e)
        {
            var proxy = new PuzzleUService.PuzzleUServiceClient();
            int id = -1;
            string errorString = string.Empty;

            int userId;
            if (!int.TryParse(textBoxCreateAlbumUserID.Text, out userId))
            {
                MessageBox.Show("User ID should be a number");
            }

            string albumName = textBoxCreateAlbumAlbumName.Text;
            if (string.IsNullOrEmpty(albumName))
            {
                MessageBox.Show("Please input album name");
            }

            if (proxy.CreateAlbum(out id, out errorString, userId, albumName))
                this.textBoxCreateAlbumAlbumID.Text = id.ToString();
            else
                this.textBoxCreateAlbumAlbumID.Text = errorString;

            UpdateUI();
        }

        private void buttonGetAlbum_Click(object sender, EventArgs e)
        {
            var proxy = new PuzzleUService.PuzzleUServiceClient();
            int id = -1;
            string errorString = string.Empty;

            int userId;
            if (!int.TryParse(textBoxGetAlbumUserID.Text, out userId))
            {
                MessageBox.Show("User ID should be a number");
            }

            string albumName = textBoxGetAlbumAlbumName.Text;
            if (string.IsNullOrEmpty(albumName))
            {
                MessageBox.Show("Please input album name");
            }

            if (proxy.GetAlbumID(out id, out errorString, userId, albumName))
                this.textBoxGetAlbumAlbumID.Text = id.ToString();
            else
                this.textBoxGetAlbumAlbumID.Text = errorString;

            UpdateUI();
        }

        private void buttonDeleteAlbum_Click(object sender, EventArgs e)
        {
            string idStr = textBoxDeleteAlbumAlbumID.Text;
            int id = -1;
            if (int.TryParse(idStr, out id))
            {
                var proxy = new PuzzleUService.PuzzleUServiceClient();
                string errorString = string.Empty;

                if (proxy.DeleteAlbum(out errorString, id))
                    textBoxDeleteAlbumResult.Text = "Album deleted";
                else
                    textBoxDeleteAlbumResult.Text = errorString;
            }
            else
                textBoxDeleteAlbumResult.Text = "Illegal Album ID";


            UpdateUI();
        }

        private void buttonUserAlbumsGet_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
