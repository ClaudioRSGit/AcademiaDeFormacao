﻿namespace AcademiaDeFormacao.UserControls
{
    partial class TrainingDay
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
            this.lb_days = new System.Windows.Forms.Label();
            this.lbl_trainer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_days
            // 
            this.lb_days.AutoSize = true;
            this.lb_days.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_days.Location = new System.Drawing.Point(4, 4);
            this.lb_days.Name = "lb_days";
            this.lb_days.Size = new System.Drawing.Size(21, 16);
            this.lb_days.TabIndex = 0;
            this.lb_days.Text = "00";
            // 
            // lbl_trainer
            // 
            this.lbl_trainer.AutoSize = true;
            this.lbl_trainer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_trainer.ForeColor = System.Drawing.Color.Lime;
            this.lbl_trainer.Location = new System.Drawing.Point(15, 45);
            this.lbl_trainer.Name = "lbl_trainer";
            this.lbl_trainer.Size = new System.Drawing.Size(10, 16);
            this.lbl_trainer.TabIndex = 1;
            this.lbl_trainer.Text = " ";
            // 
            // TrainingDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.lbl_trainer);
            this.Controls.Add(this.lb_days);
            this.Name = "TrainingDay";
            this.Size = new System.Drawing.Size(110, 97);
            this.Click += new System.EventHandler(this.TrainingDay_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_days;
        private System.Windows.Forms.Label lbl_trainer;
    }
}
