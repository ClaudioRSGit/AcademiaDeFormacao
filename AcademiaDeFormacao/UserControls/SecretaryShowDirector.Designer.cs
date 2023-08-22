namespace AcademiaDeFormacao.UserControls
{
    partial class SecretaryShowDirector
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
            this.label1 = new System.Windows.Forms.Label();
            this.list_Directors = new System.Windows.Forms.ListBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "DIRECTORS";
            // 
            // list_Directors
            // 
            this.list_Directors.FormattingEnabled = true;
            this.list_Directors.ItemHeight = 16;
            this.list_Directors.Location = new System.Drawing.Point(19, 57);
            this.list_Directors.Name = "list_Directors";
            this.list_Directors.Size = new System.Drawing.Size(221, 180);
            this.list_Directors.TabIndex = 1;
            this.list_Directors.SelectedIndexChanged += new System.EventHandler(this.list_Directors_SelectedIndexChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(19, 252);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(95, 32);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(145, 252);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(95, 32);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text = "BACK";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // SecretaryShowDirector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.list_Directors);
            this.Controls.Add(this.label1);
            this.Name = "SecretaryShowDirector";
            this.Size = new System.Drawing.Size(268, 309);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_Directors;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_back;
    }
}
