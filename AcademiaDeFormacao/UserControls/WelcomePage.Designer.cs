namespace AcademiaDeFormacao.UserControls
{
    partial class WelcomePage
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_Form1_Data = new System.Windows.Forms.Label();
            this.label_Hora = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_Form1_Data
            // 
            this.label_Form1_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Form1_Data.AutoSize = true;
            this.label_Form1_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Form1_Data.ForeColor = System.Drawing.Color.White;
            this.label_Form1_Data.Location = new System.Drawing.Point(371, 387);
            this.label_Form1_Data.Name = "label_Form1_Data";
            this.label_Form1_Data.Size = new System.Drawing.Size(160, 15);
            this.label_Form1_Data.TabIndex = 24;
            this.label_Form1_Data.Text = "Saturday, April 15, 2023";
            this.label_Form1_Data.Click += new System.EventHandler(this.label_Form1_Data_Click);
            // 
            // label_Hora
            // 
            this.label_Hora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Hora.AutoSize = true;
            this.label_Hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hora.ForeColor = System.Drawing.Color.White;
            this.label_Hora.Location = new System.Drawing.Point(669, 387);
            this.label_Hora.Name = "label_Hora";
            this.label_Hora.Size = new System.Drawing.Size(78, 15);
            this.label_Hora.TabIndex = 25;
            this.label_Hora.Text = "label_Hora";
            this.label_Hora.Click += new System.EventHandler(this.label_Hora_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AcademiaDeFormacao.Properties.Resources.Untitled__10__transformed;
            this.pictureBox1.Location = new System.Drawing.Point(-480, -344);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1820, 1307);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.label_Hora);
            this.Controls.Add(this.label_Form1_Data);
            this.Controls.Add(this.pictureBox1);
            this.Name = "WelcomePage";
            this.Size = new System.Drawing.Size(817, 578);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Form1_Data;
        private System.Windows.Forms.Label label_Hora;
    }
}
