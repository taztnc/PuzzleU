namespace ServicesClient
{
    partial class FormUserName
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
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.textBoxCreateUserName = new System.Windows.Forms.TextBox();
            this.textBoxCreateUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.groupBoxDeleteUser = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDeleteResult = new System.Windows.Forms.TextBox();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.textBoxDeleteUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxGetUserID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGetUserName = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGetUserName = new System.Windows.Forms.TextBox();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxCreate.SuspendLayout();
            this.groupBoxDeleteUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(20, 61);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateUser.TabIndex = 0;
            this.buttonCreateUser.Text = "Create";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // textBoxCreateUserName
            // 
            this.textBoxCreateUserName.Location = new System.Drawing.Point(82, 24);
            this.textBoxCreateUserName.Name = "textBoxCreateUserName";
            this.textBoxCreateUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreateUserName.TabIndex = 1;
            // 
            // textBoxCreateUserID
            // 
            this.textBoxCreateUserID.Location = new System.Drawing.Point(167, 63);
            this.textBoxCreateUserID.Name = "textBoxCreateUserID";
            this.textBoxCreateUserID.ReadOnly = true;
            this.textBoxCreateUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreateUserID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User ID:";
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Controls.Add(this.textBoxCreateUserName);
            this.groupBoxCreate.Controls.Add(this.label3);
            this.groupBoxCreate.Controls.Add(this.buttonCreateUser);
            this.groupBoxCreate.Controls.Add(this.label2);
            this.groupBoxCreate.Controls.Add(this.textBoxCreateUserID);
            this.groupBoxCreate.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(297, 106);
            this.groupBoxCreate.TabIndex = 7;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Create User Name";
            // 
            // groupBoxDeleteUser
            // 
            this.groupBoxDeleteUser.Controls.Add(this.label6);
            this.groupBoxDeleteUser.Controls.Add(this.textBoxDeleteResult);
            this.groupBoxDeleteUser.Controls.Add(this.buttonDeleteUser);
            this.groupBoxDeleteUser.Controls.Add(this.textBoxDeleteUserID);
            this.groupBoxDeleteUser.Controls.Add(this.label1);
            this.groupBoxDeleteUser.Location = new System.Drawing.Point(12, 243);
            this.groupBoxDeleteUser.Name = "groupBoxDeleteUser";
            this.groupBoxDeleteUser.Size = new System.Drawing.Size(297, 99);
            this.groupBoxDeleteUser.TabIndex = 8;
            this.groupBoxDeleteUser.TabStop = false;
            this.groupBoxDeleteUser.Text = "Delete User";
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
            // textBoxDeleteResult
            // 
            this.textBoxDeleteResult.Location = new System.Drawing.Point(172, 63);
            this.textBoxDeleteResult.Name = "textBoxDeleteResult";
            this.textBoxDeleteResult.ReadOnly = true;
            this.textBoxDeleteResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteResult.TabIndex = 10;
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(20, 63);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteUser.TabIndex = 9;
            this.buttonDeleteUser.Text = "Delete";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // textBoxDeleteUserID
            // 
            this.textBoxDeleteUserID.Location = new System.Drawing.Point(82, 22);
            this.textBoxDeleteUserID.Name = "textBoxDeleteUserID";
            this.textBoxDeleteUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteUserID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "User ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxGetUserID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonGetUserName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxGetUserName);
            this.groupBox1.Location = new System.Drawing.Point(14, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get User ID";
            // 
            // textBoxGetUserID
            // 
            this.textBoxGetUserID.Location = new System.Drawing.Point(168, 55);
            this.textBoxGetUserID.Name = "textBoxGetUserID";
            this.textBoxGetUserID.ReadOnly = true;
            this.textBoxGetUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxGetUserID.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "User ID:";
            // 
            // buttonGetUserName
            // 
            this.buttonGetUserName.Location = new System.Drawing.Point(21, 53);
            this.buttonGetUserName.Name = "buttonGetUserName";
            this.buttonGetUserName.Size = new System.Drawing.Size(75, 23);
            this.buttonGetUserName.TabIndex = 7;
            this.buttonGetUserName.Text = "Get";
            this.buttonGetUserName.UseVisualStyleBackColor = true;
            this.buttonGetUserName.Click += new System.EventHandler(this.buttonGetUserName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "User Name:";
            // 
            // textBoxGetUserName
            // 
            this.textBoxGetUserName.Location = new System.Drawing.Point(83, 16);
            this.textBoxGetUserName.Name = "textBoxGetUserName";
            this.textBoxGetUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxGetUserName.TabIndex = 8;
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(371, 39);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(737, 264);
            this.listBoxUsers.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Users:";
            // 
            // FormUserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 363);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDeleteUser);
            this.Controls.Add(this.groupBoxCreate);
            this.Name = "FormUserName";
            this.Text = "User Name tests";
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxCreate.PerformLayout();
            this.groupBoxDeleteUser.ResumeLayout(false);
            this.groupBoxDeleteUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.TextBox textBoxCreateUserName;
        private System.Windows.Forms.TextBox textBoxCreateUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.GroupBox groupBoxDeleteUser;
        private System.Windows.Forms.TextBox textBoxDeleteUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxGetUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGetUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGetUserName;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDeleteResult;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Label label7;
    }
}

