namespace ServicesClient
{
    partial class FormUserMetaData
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
            this.buttonGetUserMetaData = new System.Windows.Forms.Button();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.treeViewUser = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // buttonGetUserMetaData
            // 
            this.buttonGetUserMetaData.Location = new System.Drawing.Point(12, 12);
            this.buttonGetUserMetaData.Name = "buttonGetUserMetaData";
            this.buttonGetUserMetaData.Size = new System.Drawing.Size(111, 27);
            this.buttonGetUserMetaData.TabIndex = 1;
            this.buttonGetUserMetaData.Text = "Get User Meta Data";
            this.buttonGetUserMetaData.UseVisualStyleBackColor = true;
            this.buttonGetUserMetaData.Click += new System.EventHandler(this.buttonGetUserMetaData_Click);
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(159, 16);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserId.TabIndex = 2;
            // 
            // treeViewUser
            // 
            this.treeViewUser.Location = new System.Drawing.Point(13, 64);
            this.treeViewUser.Name = "treeViewUser";
            this.treeViewUser.Size = new System.Drawing.Size(505, 388);
            this.treeViewUser.TabIndex = 3;
            // 
            // FormUserMetaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 464);
            this.Controls.Add(this.treeViewUser);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.buttonGetUserMetaData);
            this.Name = "FormUserMetaData";
            this.Text = "FormUserMetaData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetUserMetaData;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.TreeView treeViewUser;
    }
}