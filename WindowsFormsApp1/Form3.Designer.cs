namespace WindowsFormsApp1
{
    partial class Form3
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
            this.tb_hoten = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_mssv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_hoten
            // 
            this.tb_hoten.Location = new System.Drawing.Point(134, 75);
            this.tb_hoten.Name = "tb_hoten";
            this.tb_hoten.Size = new System.Drawing.Size(385, 26);
            this.tb_hoten.TabIndex = 0;
            this.tb_hoten.TextChanged += new System.EventHandler(this.tb_hoten_TextChanged);
            this.tb_hoten.Validating += new System.ComponentModel.CancelEventHandler(this.tb_hoten_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ và tên";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(586, 63);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(120, 51);
            this.btn_them.TabIndex = 2;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(586, 157);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(120, 62);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // tb_sdt
            // 
            this.tb_sdt.Location = new System.Drawing.Point(134, 140);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(385, 26);
            this.tb_sdt.TabIndex = 0;
            this.tb_sdt.TextChanged += new System.EventHandler(this.tb_sdt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại";
            // 
            // tb_mssv
            // 
            this.tb_mssv.Location = new System.Drawing.Point(134, 21);
            this.tb_mssv.Name = "tb_mssv";
            this.tb_mssv.Size = new System.Drawing.Size(385, 26);
            this.tb_mssv.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "MSSV";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_mssv);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_sdt);
            this.Controls.Add(this.tb_hoten);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Move += new System.EventHandler(this.Form3_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_hoten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_mssv;
        private System.Windows.Forms.Label label3;
    }
}