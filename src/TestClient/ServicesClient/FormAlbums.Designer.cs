namespace ServicesClient
{
    partial class FormAlbums
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
            this.buttonCreateAlbum = new System.Windows.Forms.Button();
            this.textBoxCreateAlbumUserID = new System.Windows.Forms.TextBox();
            this.textBoxCreateAlbumAlbumID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.groupBoxDeleteUser = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDeleteAlbumResult = new System.Windows.Forms.TextBox();
            this.buttonDeleteAlbum = new System.Windows.Forms.Button();
            this.textBoxDeleteAlbumAlbumID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCreateAlbumAlbumName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxGetAlbumAlbumName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGetAlbumAlbumID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGetAlbum = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxGetAlbumUserID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxUserAlbumsUserID = new System.Windows.Forms.TextBox();
            this.buttonUserAlbumsGet = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxCreate.SuspendLayout();
            this.groupBoxDeleteUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateAlbum
            // 
            this.buttonCreateAlbum.Location = new System.Drawing.Point(20, 84);
            this.buttonCreateAlbum.Name = "buttonCreateAlbum";
            this.buttonCreateAlbum.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateAlbum.TabIndex = 0;
            this.buttonCreateAlbum.Text = "Create";
            this.buttonCreateAlbum.UseVisualStyleBackColor = true;
            this.buttonCreateAlbum.Click += new System.EventHandler(this.buttonCreateAlbum_Click);
            // 
            // textBoxCreateAlbumUserID
            // 
            this.textBoxCreateAlbumUserID.Location = new System.Drawing.Point(98, 24);
            this.textBoxCreateAlbumUserID.Name = "textBoxCreateAlbumUserID";
            this.textBoxCreateAlbumUserID.Size = new System.Drawing.Size(131, 20);
            this.textBoxCreateAlbumUserID.TabIndex = 1;
            // 
            // textBoxCreateAlbumAlbumID
            // 
            this.textBoxCreateAlbumAlbumID.Location = new System.Drawing.Point(174, 86);
            this.textBoxCreateAlbumAlbumID.Name = "textBoxCreateAlbumAlbumID";
            this.textBoxCreateAlbumAlbumID.ReadOnly = true;
            this.textBoxCreateAlbumAlbumID.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreateAlbumAlbumID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Album ID:";
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Controls.Add(this.textBoxCreateAlbumAlbumName);
            this.groupBoxCreate.Controls.Add(this.label8);
            this.groupBoxCreate.Controls.Add(this.textBoxCreateAlbumAlbumID);
            this.groupBoxCreate.Controls.Add(this.label3);
            this.groupBoxCreate.Controls.Add(this.buttonCreateAlbum);
            this.groupBoxCreate.Controls.Add(this.label2);
            this.groupBoxCreate.Controls.Add(this.textBoxCreateAlbumUserID);
            this.groupBoxCreate.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(297, 136);
            this.groupBoxCreate.TabIndex = 7;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Create Album";
            // 
            // groupBoxDeleteUser
            // 
            this.groupBoxDeleteUser.Controls.Add(this.label6);
            this.groupBoxDeleteUser.Controls.Add(this.textBoxDeleteAlbumResult);
            this.groupBoxDeleteUser.Controls.Add(this.buttonDeleteAlbum);
            this.groupBoxDeleteUser.Controls.Add(this.textBoxDeleteAlbumAlbumID);
            this.groupBoxDeleteUser.Controls.Add(this.label1);
            this.groupBoxDeleteUser.Location = new System.Drawing.Point(12, 302);
            this.groupBoxDeleteUser.Name = "groupBoxDeleteUser";
            this.groupBoxDeleteUser.Size = new System.Drawing.Size(297, 99);
            this.groupBoxDeleteUser.TabIndex = 8;
            this.groupBoxDeleteUser.TabStop = false;
            this.groupBoxDeleteUser.Text = "Delete Album";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Result:";
            // 
            // textBoxDeleteAlbumResult
            // 
            this.textBoxDeleteAlbumResult.Location = new System.Drawing.Point(172, 63);
            this.textBoxDeleteAlbumResult.Name = "textBoxDeleteAlbumResult";
            this.textBoxDeleteAlbumResult.ReadOnly = true;
            this.textBoxDeleteAlbumResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteAlbumResult.TabIndex = 10;
            // 
            // buttonDeleteAlbum
            // 
            this.buttonDeleteAlbum.Location = new System.Drawing.Point(20, 63);
            this.buttonDeleteAlbum.Name = "buttonDeleteAlbum";
            this.buttonDeleteAlbum.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteAlbum.TabIndex = 9;
            this.buttonDeleteAlbum.Text = "Delete";
            this.buttonDeleteAlbum.UseVisualStyleBackColor = true;
            this.buttonDeleteAlbum.Click += new System.EventHandler(this.buttonDeleteAlbum_Click);
            // 
            // textBoxDeleteAlbumAlbumID
            // 
            this.textBoxDeleteAlbumAlbumID.Location = new System.Drawing.Point(82, 22);
            this.textBoxDeleteAlbumAlbumID.Name = "textBoxDeleteAlbumAlbumID";
            this.textBoxDeleteAlbumAlbumID.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteAlbumAlbumID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Album ID:";
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.Location = new System.Drawing.Point(42, 78);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(206, 264);
            this.listBoxAlbums.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(488, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Albums:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Album Name:";
            // 
            // textBoxCreateAlbumAlbumName
            // 
            this.textBoxCreateAlbumAlbumName.Location = new System.Drawing.Point(98, 47);
            this.textBoxCreateAlbumAlbumName.Name = "textBoxCreateAlbumAlbumName";
            this.textBoxCreateAlbumAlbumName.Size = new System.Drawing.Size(131, 20);
            this.textBoxCreateAlbumAlbumName.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxGetAlbumAlbumName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxGetAlbumAlbumID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonGetAlbum);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxGetAlbumUserID);
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 136);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Album";
            // 
            // textBoxGetAlbumAlbumName
            // 
            this.textBoxGetAlbumAlbumName.Location = new System.Drawing.Point(98, 47);
            this.textBoxGetAlbumAlbumName.Name = "textBoxGetAlbumAlbumName";
            this.textBoxGetAlbumAlbumName.Size = new System.Drawing.Size(131, 20);
            this.textBoxGetAlbumAlbumName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Album Name:";
            // 
            // textBoxGetAlbumAlbumID
            // 
            this.textBoxGetAlbumAlbumID.Location = new System.Drawing.Point(174, 86);
            this.textBoxGetAlbumAlbumID.Name = "textBoxGetAlbumAlbumID";
            this.textBoxGetAlbumAlbumID.ReadOnly = true;
            this.textBoxGetAlbumAlbumID.Size = new System.Drawing.Size(100, 20);
            this.textBoxGetAlbumAlbumID.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Album ID:";
            // 
            // buttonGetAlbum
            // 
            this.buttonGetAlbum.Location = new System.Drawing.Point(20, 84);
            this.buttonGetAlbum.Name = "buttonGetAlbum";
            this.buttonGetAlbum.Size = new System.Drawing.Size(75, 23);
            this.buttonGetAlbum.TabIndex = 0;
            this.buttonGetAlbum.Text = "Create";
            this.buttonGetAlbum.UseVisualStyleBackColor = true;
            this.buttonGetAlbum.Click += new System.EventHandler(this.buttonGetAlbum_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "User ID:";
            // 
            // textBoxGetAlbumUserID
            // 
            this.textBoxGetAlbumUserID.Location = new System.Drawing.Point(98, 24);
            this.textBoxGetAlbumUserID.Name = "textBoxGetAlbumUserID";
            this.textBoxGetAlbumUserID.Size = new System.Drawing.Size(131, 20);
            this.textBoxGetAlbumUserID.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonUserAlbumsGet);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBoxUserAlbumsUserID);
            this.groupBox2.Controls.Add(this.listBoxAlbums);
            this.groupBox2.Location = new System.Drawing.Point(374, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 370);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Albums";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "User ID:";
            // 
            // textBoxUserAlbumsUserID
            // 
            this.textBoxUserAlbumsUserID.Location = new System.Drawing.Point(106, 22);
            this.textBoxUserAlbumsUserID.Name = "textBoxUserAlbumsUserID";
            this.textBoxUserAlbumsUserID.Size = new System.Drawing.Size(131, 20);
            this.textBoxUserAlbumsUserID.TabIndex = 11;
            // 
            // buttonUserAlbumsGet
            // 
            this.buttonUserAlbumsGet.Location = new System.Drawing.Point(255, 20);
            this.buttonUserAlbumsGet.Name = "buttonUserAlbumsGet";
            this.buttonUserAlbumsGet.Size = new System.Drawing.Size(75, 23);
            this.buttonUserAlbumsGet.TabIndex = 13;
            this.buttonUserAlbumsGet.Text = "Get";
            this.buttonUserAlbumsGet.UseVisualStyleBackColor = true;
            this.buttonUserAlbumsGet.Click += new System.EventHandler(this.buttonUserAlbumsGet_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "User Albums:";
            // 
            // FormAlbums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 425);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBoxDeleteUser);
            this.Controls.Add(this.groupBoxCreate);
            this.Name = "FormAlbums";
            this.Text = "Albums tests";
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxCreate.PerformLayout();
            this.groupBoxDeleteUser.ResumeLayout(false);
            this.groupBoxDeleteUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateAlbum;
        private System.Windows.Forms.TextBox textBoxCreateAlbumUserID;
        private System.Windows.Forms.TextBox textBoxCreateAlbumAlbumID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.GroupBox groupBoxDeleteUser;
        private System.Windows.Forms.TextBox textBoxDeleteAlbumAlbumID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleteAlbum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDeleteAlbumResult;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCreateAlbumAlbumName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxGetAlbumAlbumName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGetAlbumAlbumID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonGetAlbum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxGetAlbumUserID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonUserAlbumsGet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxUserAlbumsUserID;
    }
}

