namespace ServicesClient
{
    partial class FormImages
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAddImageImagePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddIamge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddImageAlbumID = new System.Windows.Forms.TextBox();
            this.listBoxAlbumImages = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAlbumImagesAlbumID = new System.Windows.Forms.TextBox();
            this.groupBoxAlbumImages = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAddImageResult = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxAlbumImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAddImageResult);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxAddImageAlbumID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonAddIamge);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxAddImageImagePath);
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Image";
            // 
            // textBoxAddImageImagePath
            // 
            this.textBoxAddImageImagePath.Location = new System.Drawing.Point(84, 52);
            this.textBoxAddImageImagePath.Name = "textBoxAddImageImagePath";
            this.textBoxAddImageImagePath.Size = new System.Drawing.Size(449, 20);
            this.textBoxAddImageImagePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path:";
            // 
            // buttonAddIamge
            // 
            this.buttonAddIamge.Location = new System.Drawing.Point(86, 94);
            this.buttonAddIamge.Name = "buttonAddIamge";
            this.buttonAddIamge.Size = new System.Drawing.Size(75, 23);
            this.buttonAddIamge.TabIndex = 2;
            this.buttonAddIamge.Text = "Add Image";
            this.buttonAddIamge.UseVisualStyleBackColor = true;
            this.buttonAddIamge.Click += new System.EventHandler(this.buttonAddIamge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Album ID:";
            // 
            // textBoxAddImageAlbumID
            // 
            this.textBoxAddImageAlbumID.Location = new System.Drawing.Point(84, 22);
            this.textBoxAddImageAlbumID.Name = "textBoxAddImageAlbumID";
            this.textBoxAddImageAlbumID.Size = new System.Drawing.Size(89, 20);
            this.textBoxAddImageAlbumID.TabIndex = 4;
            // 
            // listBoxAlbumImages
            // 
            this.listBoxAlbumImages.FormattingEnabled = true;
            this.listBoxAlbumImages.Location = new System.Drawing.Point(29, 72);
            this.listBoxAlbumImages.Name = "listBoxAlbumImages";
            this.listBoxAlbumImages.Size = new System.Drawing.Size(188, 264);
            this.listBoxAlbumImages.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Album Images:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Album ID:";
            // 
            // textBoxAlbumImagesAlbumID
            // 
            this.textBoxAlbumImagesAlbumID.Location = new System.Drawing.Point(88, 19);
            this.textBoxAlbumImagesAlbumID.Name = "textBoxAlbumImagesAlbumID";
            this.textBoxAlbumImagesAlbumID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlbumImagesAlbumID.TabIndex = 4;
            // 
            // groupBoxAlbumImages
            // 
            this.groupBoxAlbumImages.Controls.Add(this.listBoxAlbumImages);
            this.groupBoxAlbumImages.Controls.Add(this.textBoxAlbumImagesAlbumID);
            this.groupBoxAlbumImages.Controls.Add(this.label3);
            this.groupBoxAlbumImages.Controls.Add(this.label4);
            this.groupBoxAlbumImages.Location = new System.Drawing.Point(591, 23);
            this.groupBoxAlbumImages.Name = "groupBoxAlbumImages";
            this.groupBoxAlbumImages.Size = new System.Drawing.Size(233, 345);
            this.groupBoxAlbumImages.TabIndex = 5;
            this.groupBoxAlbumImages.TabStop = false;
            this.groupBoxAlbumImages.Text = "Album Images";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Result:";
            // 
            // textBoxAddImageResult
            // 
            this.textBoxAddImageResult.Location = new System.Drawing.Point(235, 96);
            this.textBoxAddImageResult.Name = "textBoxAddImageResult";
            this.textBoxAddImageResult.Size = new System.Drawing.Size(205, 20);
            this.textBoxAddImageResult.TabIndex = 6;
            // 
            // FormImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 380);
            this.Controls.Add(this.groupBoxAlbumImages);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormImages";
            this.Text = "Album Images Tests";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAlbumImages.ResumeLayout(false);
            this.groupBoxAlbumImages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAddImageAlbumID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddIamge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAddImageImagePath;
        private System.Windows.Forms.ListBox listBoxAlbumImages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAlbumImagesAlbumID;
        private System.Windows.Forms.GroupBox groupBoxAlbumImages;
        private System.Windows.Forms.TextBox textBoxAddImageResult;
        private System.Windows.Forms.Label label5;
    }
}