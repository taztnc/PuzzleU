using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ServicesClient
{
    public partial class FormImages : Form
    {
        public FormImages()
        {
            InitializeComponent();
            UpdateUI();

        }

        private void UpdateUI()
        {
            int albumId;
            if (!int.TryParse(textBoxAlbumImagesAlbumID.Text, out albumId))
                return;

            var proxy = new PuzzleUService.PuzzleUServiceClient();
            string errorString = string.Empty;

            listBoxAlbumImages.Items.Clear();
            string[] images = null;

            if (!proxy.GetAlbumImages(out images, out errorString, albumId))
            {
                listBoxAlbumImages.Items.Add(errorString);
                return;
            }

            foreach (string image in images)
            {
                listBoxAlbumImages.Items.Add(image);
            }
        }

        private void buttonAddIamge_Click(object sender, EventArgs e)
        {
            string path = textBoxAddImageImagePath.Text;

            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exist");
                return;
            }

            var proxy = new PuzzleUService.PuzzleUServiceClient();            
            string errorString = string.Empty;

            int albumId;
            if (!int.TryParse(textBoxAddImageAlbumID.Text, out albumId))
            {
                MessageBox.Show("Album ID should be a number");
                return;
            }

            byte[] imageByteData = File.ReadAllBytes(path);

            PuzzleUService.ImageFileData imageFileData = new PuzzleUService.ImageFileData();
            imageFileData.ImageName = Path.GetFileName(path);
            imageFileData.ImageFormat = Path.GetExtension(path);
            imageFileData.ImageStream = imageByteData;

            if (!proxy.AddImage(out errorString, albumId, imageFileData))
                textBoxAddImageResult.Text = errorString;
            else
                textBoxAddImageResult.Text = "Success";

            UpdateUI();
        }

        private void buttonDeleteImage_Click(object sender, EventArgs e)
        {
            string name = textBoxDeleteImageImageName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Image name is required");
                return;
            }

            var proxy = new PuzzleUService.PuzzleUServiceClient();
            string errorString = string.Empty;

            int albumId;
            if (!int.TryParse(textBoxDeleteImageAlbumID.Text, out albumId))
            {
                MessageBox.Show("Album ID should be a number");
                return;
            }

            if (!proxy.DeleteImage(out errorString, albumId, name))
                textBoxDeleteImageResult.Text = errorString;
            else
                textBoxDeleteImageResult.Text = "Success";

            UpdateUI();
        }

        private void buttonAlbumImagesGet_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
