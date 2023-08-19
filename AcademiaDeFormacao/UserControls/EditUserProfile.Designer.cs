namespace AcademiaDeFormacao.UserControls
{
    partial class EditUserProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_title = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(440, 132);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(97, 16);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "EDIT PROFILE";
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(478, 179);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(44, 16);
            this.test.TabIndex = 1;
            this.test.Text = "label1";
            // 
            // EditUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.test);
            this.Controls.Add(this.lbl_title);
            this.Name = "EditUserProfile";
            this.Size = new System.Drawing.Size(816, 578);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label test;
    }
}
