namespace AcademiaDeFormacao
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.loginPanel1 = new AcademiaDeFormacao.loginPanel();
            this.registerPanel1 = new AcademiaDeFormacao.registerPanel();
            this.SuspendLayout();
            // 
            // loginPanel1
            // 
            this.loginPanel1.Location = new System.Drawing.Point(2, -4);
            this.loginPanel1.Name = "loginPanel1";
            this.loginPanel1.Size = new System.Drawing.Size(900, 541);
            this.loginPanel1.TabIndex = 0;
            // 
            // registerPanel1
            // 
            this.registerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.registerPanel1.Location = new System.Drawing.Point(-15, -13);
            this.registerPanel1.Name = "registerPanel1";
            this.registerPanel1.Size = new System.Drawing.Size(960, 569);
            this.registerPanel1.TabIndex = 1;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 518);
            this.Controls.Add(this.loginPanel1);
            this.Controls.Add(this.registerPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.Text = "School Management System";
            this.ResumeLayout(false);

        }

        #endregion

        private loginPanel loginPanel1;
        private registerPanel registerPanel1;
    }
}

