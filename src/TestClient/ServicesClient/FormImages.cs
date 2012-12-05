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

            textBoxAddImageImagePath.Text = @"C:\Temp\alerts_icon.bmp";
        }

        private void UpdateUI()
        {
           // kobig - implement
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
        }
    }
}
