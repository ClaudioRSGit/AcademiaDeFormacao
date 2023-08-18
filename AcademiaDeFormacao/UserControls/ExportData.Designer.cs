namespace AcademiaDeFormacao.UserControls
{
    partial class ExportData
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
            this.cmb_filter = new System.Windows.Forms.ComboBox();
            this.lb_Preview = new System.Windows.Forms.Label();
            this.btn_exportCSV = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(64, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 36);
            this.label1.TabIndex = 57;
            this.label1.Text = "Filter";
            // 
            // cmb_filter
            // 
            this.cmb_filter.AllowDrop = true;
            this.cmb_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filter.FormattingEnabled = true;
            this.cmb_filter.Items.AddRange(new object[] {
            "Director",
            "Secretary",
            "Trainer",
            "Coordinator",
            "All"});
            this.cmb_filter.Location = new System.Drawing.Point(120, 138);
            this.cmb_filter.Name = "cmb_filter";
            this.cmb_filter.Size = new System.Drawing.Size(155, 24);
            this.cmb_filter.TabIndex = 56;
            this.cmb_filter.SelectedIndexChanged += new System.EventHandler(this.cmb_filter_SelectedIndexChanged);
            // 
            // lb_Preview
            // 
            this.lb_Preview.AutoSize = true;
            this.lb_Preview.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Preview.ForeColor = System.Drawing.Color.Ivory;
            this.lb_Preview.Location = new System.Drawing.Point(688, 194);
            this.lb_Preview.Name = "lb_Preview";
            this.lb_Preview.Size = new System.Drawing.Size(67, 28);
            this.lb_Preview.TabIndex = 55;
            this.lb_Preview.Text = "Preview";
            // 
            // btn_exportCSV
            // 
            this.btn_exportCSV.Location = new System.Drawing.Point(55, 510);
            this.btn_exportCSV.Name = "btn_exportCSV";
            this.btn_exportCSV.Size = new System.Drawing.Size(700, 29);
            this.btn_exportCSV.TabIndex = 54;
            this.btn_exportCSV.Text = "Export to CSV";
            this.btn_exportCSV.UseVisualStyleBackColor = true;
            this.btn_exportCSV.Click += new System.EventHandler(this.btn_exportCSV_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(55, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 1);
            this.panel2.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Ivory;
            this.label2.Location = new System.Drawing.Point(46, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 49);
            this.label2.TabIndex = 52;
            this.label2.Text = "Export to CSV";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(55, 225);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(700, 251);
            this.dataGridView1.TabIndex = 58;
            // 
            // ExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_filter);
            this.Controls.Add(this.lb_Preview);
            this.Controls.Add(this.btn_exportCSV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Name = "ExportData";
            this.Size = new System.Drawing.Size(817, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_filter;
        private System.Windows.Forms.Label lb_Preview;
        private System.Windows.Forms.Button btn_exportCSV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
