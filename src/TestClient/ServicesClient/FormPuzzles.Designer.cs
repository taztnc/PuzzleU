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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxImageId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDifficultyLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPuzzleData = new System.Windows.Forms.TextBox();
            this.buttonGetPuzzleData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image Id";
            // 
            // textBoxImageId
            // 
            this.textBoxImageId.Location = new System.Drawing.Point(99, 12);
            this.textBoxImageId.Name = "textBoxImageId";
            this.textBoxImageId.Size = new System.Drawing.Size(120, 20);
            this.textBoxImageId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Difficulty Level:";
            // 
            // textBoxDifficultyLevel
            // 
            this.textBoxDifficultyLevel.Location = new System.Drawing.Point(97, 44);
            this.textBoxDifficultyLevel.Name = "textBoxDifficultyLevel";
            this.textBoxDifficultyLevel.Size = new System.Drawing.Size(128, 20);
            this.textBoxDifficultyLevel.TabIndex = 5;
            this.textBoxDifficultyLevel.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Puzzle Data:";
            // 
            // textBoxPuzzleData
            // 
            this.textBoxPuzzleData.Location = new System.Drawing.Point(12, 125);
            this.textBoxPuzzleData.Multiline = true;
            this.textBoxPuzzleData.Name = "textBoxPuzzleData";
            this.textBoxPuzzleData.Size = new System.Drawing.Size(569, 139);
            this.textBoxPuzzleData.TabIndex = 7;
            // 
            // buttonGetPuzzleData
            // 
            this.buttonGetPuzzleData.Location = new System.Drawing.Point(123, 81);
            this.buttonGetPuzzleData.Name = "buttonGetPuzzleData";
            this.buttonGetPuzzleData.Size = new System.Drawing.Size(102, 23);
            this.buttonGetPuzzleData.TabIndex = 8;
            this.buttonGetPuzzleData.Text = "Get Puzzle Data";
            this.buttonGetPuzzleData.UseVisualStyleBackColor = true;
            this.buttonGetPuzzleData.Click += new System.EventHandler(this.buttonGetPuzzleData_Click);
            // 
            // FormPuzzles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 273);
            this.Controls.Add(this.buttonGetPuzzleData);
            this.Controls.Add(this.textBoxPuzzleData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDifficultyLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxImageId);
            this.Controls.Add(this.label2);
            this.Name = "FormPuzzles";
            this.Text = "FormPuzzles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxImageId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDifficultyLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPuzzleData;
        private System.Windows.Forms.Button buttonGetPuzzleData;
    }
}