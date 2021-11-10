
namespace QLBH_ThoiTrang
{
    partial class FormThongKe
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
            this.label6 = new System.Windows.Forms.Label();
            this.panelQuanLyHoaDon = new System.Windows.Forms.Panel();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.panelQuanLyHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(405, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 44);
            this.label6.TabIndex = 20;
            this.label6.Text = "Thống Kê";
            // 
            // panelQuanLyHoaDon
            // 
            this.panelQuanLyHoaDon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelQuanLyHoaDon.Controls.Add(this.label6);
            this.panelQuanLyHoaDon.Controls.Add(this.label10);
            this.panelQuanLyHoaDon.Controls.Add(this.dgvHoaDon);
            this.panelQuanLyHoaDon.Location = new System.Drawing.Point(12, 12);
            this.panelQuanLyHoaDon.Name = "panelQuanLyHoaDon";
            this.panelQuanLyHoaDon.Size = new System.Drawing.Size(1048, 578);
            this.panelQuanLyHoaDon.TabIndex = 19;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(14, 103);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(1020, 463);
            this.dgvHoaDon.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(10, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 24);
            this.label10.TabIndex = 90;
            this.label10.Text = "Danh Sách Thống Kê";
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 590);
            this.Controls.Add(this.panelQuanLyHoaDon);
            this.Name = "FormThongKe";
            this.Text = "FormThongKe";
            this.panelQuanLyHoaDon.ResumeLayout(false);
            this.panelQuanLyHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelQuanLyHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label10;
    }
}