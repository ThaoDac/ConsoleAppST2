namespace WindowsFormsApp1
{
    partial class Form1_TraoDoiThongTin
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
            this.tb_dlChuyenSangForm2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_chuyenForm2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_dlTraVeTuForm2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_dlChuyenSangForm2
            // 
            this.tb_dlChuyenSangForm2.Location = new System.Drawing.Point(208, 80);
            this.tb_dlChuyenSangForm2.Name = "tb_dlChuyenSangForm2";
            this.tb_dlChuyenSangForm2.Size = new System.Drawing.Size(298, 26);
            this.tb_dlChuyenSangForm2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập thông tin";
            // 
            // btn_chuyenForm2
            // 
            this.btn_chuyenForm2.Location = new System.Drawing.Point(567, 67);
            this.btn_chuyenForm2.Name = "btn_chuyenForm2";
            this.btn_chuyenForm2.Size = new System.Drawing.Size(150, 53);
            this.btn_chuyenForm2.TabIndex = 2;
            this.btn_chuyenForm2.Text = "Chuyển thông tin sang form thứ 2";
            this.btn_chuyenForm2.UseVisualStyleBackColor = true;
            this.btn_chuyenForm2.Click += new System.EventHandler(this.btn_chuyenForm2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhận thông tin trả về từ Form 2";
            // 
            // tb_dlTraVeTuForm2
            // 
            this.tb_dlTraVeTuForm2.Location = new System.Drawing.Point(303, 186);
            this.tb_dlTraVeTuForm2.Name = "tb_dlTraVeTuForm2";
            this.tb_dlTraVeTuForm2.Size = new System.Drawing.Size(414, 26);
            this.tb_dlTraVeTuForm2.TabIndex = 4;
            // 
            // Form1_TraoDoiThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_dlTraVeTuForm2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_chuyenForm2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_dlChuyenSangForm2);
            this.Name = "Form1_TraoDoiThongTin";
            this.Text = "Form1_TraoDoiThongTin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_dlChuyenSangForm2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_chuyenForm2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_dlTraVeTuForm2;
    }
}