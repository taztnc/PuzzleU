using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ServicesClient
{
    public partial class FormPuzzles : Form
    {
        public FormPuzzles()
        {
            InitializeComponent();
        }

        private void buttonGetPuzzleData_Click(object sender, EventArgs e)
        {
            int albumId = -1;

            if (!int.TryParse(textBoxAlbumId.Text, out albumId))
            {
                MessageBox.Show("Album ID should be an int");
                return;
            }

            if (string.IsNullOrEmpty(textBoxImageName.Text))
            {
                MessageBox.Show("Please add an image name");
                return;
            }

            int difficultyLevel = -1;
            if (!int.TryParse(textBoxDifficultyLevel.Text, out difficultyLevel))
            {
                MessageBox.Show("Difficulty level should be an int");
                return;
            }

            var proxy = new PuzzleUService.PuzzleUServiceClient();
            PuzzleUService.PuzzleData puzzleData;
            string errorString = string.Empty;
            if (!proxy.GetPuzzleData(out puzzleData, out errorString, albumId, textBoxImageName.Text, difficultyLevel))
            {
                textBoxPuzzleData.Text = errorString;
                return;
            }

            string jsonFormat = string.Empty;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PuzzleUService.PuzzleData));
            ser.WriteObject(stream1, puzzleData);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            jsonFormat = sr.ReadToEnd();

            textBoxPuzzleData.Text = jsonFormat;
        }
    }
}
