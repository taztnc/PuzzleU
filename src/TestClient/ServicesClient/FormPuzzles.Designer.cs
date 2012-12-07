namespace ServicesClient
{
    partial class FormPuzzles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxImageName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDifficultyLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPuzzleData = new System.Windows.Forms.TextBox();
            this.buttonGetPuzzleData = new System.Windows.Forms.Button();
            this.textBoxAlbumId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Album ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image Name:";
            // 
            // textBoxImageName
            // 
            this.textBoxImageName.Location = new System.Drawing.Point(99, 59);
            this.textBoxImageName.Name = "textBoxImageName";
            this.textBoxImageName.Size = new System.Drawing.Size(120, 20);
            this.textBoxImageName.TabIndex = 3;
            this.textBoxImageName.Text = "alerts_icon.bmp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Difficulty Level:";
            // 
            // textBoxDifficultyLevel
            // 
            this.textBoxDifficultyLevel.Location = new System.Drawing.Point(97, 91);
            this.textBoxDifficultyLevel.Name = "textBoxDifficultyLevel";
            this.textBoxDifficultyLevel.Size = new System.Drawing.Size(128, 20);
            this.textBoxDifficultyLevel.TabIndex = 5;
            this.textBoxDifficultyLevel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Puzzle Data:";
            // 
            // textBoxPuzzleData
            // 
            this.textBoxPuzzleData.Location = new System.Drawing.Point(18, 182);
            this.textBoxPuzzleData.Multiline = true;
            this.textBoxPuzzleData.Name = "textBoxPuzzleData";
            this.textBoxPuzzleData.Size = new System.Drawing.Size(569, 139);
            this.textBoxPuzzleData.TabIndex = 7;
            // 
            // buttonGetPuzzleData
            // 
            this.buttonGetPuzzleData.Location = new System.Drawing.Point(123, 128);
            this.buttonGetPuzzleData.Name = "buttonGetPuzzleData";
            this.buttonGetPuzzleData.Size = new System.Drawing.Size(102, 23);
            this.buttonGetPuzzleData.TabIndex = 8;
            this.buttonGetPuzzleData.Text = "Get Puzzle Data";
            this.buttonGetPuzzleData.UseVisualStyleBackColor = true;
            this.buttonGetPuzzleData.Click += new System.EventHandler(this.buttonGetPuzzleData_Click);
            // 
            // textBoxAlbumId
            // 
            this.textBoxAlbumId.Location = new System.Drawing.Point(99, 28);
            this.textBoxAlbumId.Name = "textBoxAlbumId";
            this.textBoxAlbumId.Size = new System.Drawing.Size(120, 20);
            this.textBoxAlbumId.TabIndex = 0;
            this.textBoxAlbumId.Text = "0";
            // 
            // FormPuzzles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 362);
            this.Controls.Add(this.buttonGetPuzzleData);
            this.Controls.Add(this.textBoxPuzzleData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDifficultyLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxImageName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAlbumId);
            this.Name = "FormPuzzles";
            this.Text = "FormPuzzles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxImageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDifficultyLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPuzzleData;
        private System.Windows.Forms.Button buttonGetPuzzleData;
        private System.Windows.Forms.TextBox textBoxAlbumId;
    }
}