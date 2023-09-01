namespace AcademiaDeFormacao
{
    partial class Scheduler
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
            this.btn_saveTraining = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_classes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_trainers = new System.Windows.Forms.ComboBox();
            this.dt_trainingEndDate = new System.Windows.Forms.DateTimePicker();
            this.dt_trainingStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_saveTraining
            // 
            this.btn_saveTraining.Location = new System.Drawing.Point(598, 236);
            this.btn_saveTraining.Name = "btn_saveTraining";
            this.btn_saveTraining.Size = new System.Drawing.Size(143, 28);
            this.btn_saveTraining.TabIndex = 18;
            this.btn_saveTraining.Text = "Save";
            this.btn_saveTraining.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(437, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Class";
            // 
            // cmb_classes
            // 
            this.cmb_classes.FormattingEnabled = true;
            this.cmb_classes.Location = new System.Drawing.Point(495, 191);
            this.cmb_classes.Name = "cmb_classes";
            this.cmb_classes.Size = new System.Drawing.Size(246, 24);
            this.cmb_classes.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(410, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ending at";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(76, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Trainer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(264, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "Training Scheduler";
            // 
            // cmb_trainers
            // 
            this.cmb_trainers.FormattingEnabled = true;
            this.cmb_trainers.Location = new System.Drawing.Point(144, 191);
            this.cmb_trainers.Name = "cmb_trainers";
            this.cmb_trainers.Size = new System.Drawing.Size(247, 24);
            this.cmb_trainers.TabIndex = 12;
            // 
            // dt_trainingEndDate
            // 
            this.dt_trainingEndDate.Location = new System.Drawing.Point(495, 119);
            this.dt_trainingEndDate.Name = "dt_trainingEndDate";
            this.dt_trainingEndDate.Size = new System.Drawing.Size(246, 22);
            this.dt_trainingEndDate.TabIndex = 11;
            // 
            // dt_trainingStartDate
            // 
            this.dt_trainingStartDate.Location = new System.Drawing.Point(144, 119);
            this.dt_trainingStartDate.Name = "dt_trainingStartDate";
            this.dt_trainingStartDate.Size = new System.Drawing.Size(247, 22);
            this.dt_trainingStartDate.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(52, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Starting at";
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(780, 321);
            this.Controls.Add(this.btn_saveTraining);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_classes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_trainers);
            this.Controls.Add(this.dt_trainingEndDate);
            this.Controls.Add(this.dt_trainingStartDate);
            this.Controls.Add(this.label1);
            this.Name = "Scheduler";
            this.Text = "Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_saveTraining;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_classes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_trainers;
        private System.Windows.Forms.DateTimePicker dt_trainingEndDate;
        private System.Windows.Forms.DateTimePicker dt_trainingStartDate;
        private System.Windows.Forms.Label label1;
    }
}