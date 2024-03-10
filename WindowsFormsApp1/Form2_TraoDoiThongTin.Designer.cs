namespace WindowsFormsApp1
{
    partial class Form2_TraoDoiThongTin
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_dlNhanTuForm1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_dtChuyenVeForm1 = new System.Windows.Forms.TextBox();
            this.btn_ChuyenDLForm1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin nhận được từ form 1";
            // 
            // tb_dlNhanTuForm1
            // 
            this.tb_dlNhanTuForm1.Location = new System.Drawing.Point(304, 70);
            this.tb_dlNhanTuForm1.Name = "tb_dlNhanTuForm1";
            this.tb_dlNhanTuForm1.ReadOnly = true;
            this.tb_dlNhanTuForm1.Size = new System.Drawing.Size(342, 26);
            this.tb_dlNhanTuForm1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thông tin chuyển về form 1";
            // 
            // tb_dtChuyenVeForm1
            // 
            this.tb_dtChuyenVeForm1.Location = new System.Drawing.Point(304, 163);
            this.tb_dtChuyenVeForm1.Name = "tb_dtChuyenVeForm1";
            this.tb_dtChuyenVeForm1.Size = new System.Drawing.Size(342, 26);
            this.tb_dtChuyenVeForm1.TabIndex = 3;
            this.tb_dtChuyenVeForm1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_dtChuyenVeForm1_KeyDown);
            // 
            // btn_ChuyenDLForm1
            // 
            this.btn_ChuyenDLForm1.Location = new System.Drawing.Point(676, 144);
            this.btn_ChuyenDLForm1.Name = "btn_ChuyenDLForm1";
            this.btn_ChuyenDLForm1.Size = new System.Drawing.Size(135, 64);
            this.btn_ChuyenDLForm1.TabIndex = 4;
            this.btn_ChuyenDLForm1.Text = "Chuyển thông tin về Form 1";
            this.btn_ChuyenDLForm1.UseVisualStyleBackColor = true;
            this.btn_ChuyenDLForm1.Click += new System.EventHandler(this.btn_ChuyenDLForm1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Form2_TraoDoiThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 450);
            this.Controls.Add(this.btn_ChuyenDLForm1);
            this.Controls.Add(this.tb_dtChuyenVeForm1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_dlNhanTuForm1);
            this.Controls.Add(this.label1);
            this.Name = "Form2_TraoDoiThongTin";
            this.Text = "Form2_TraoDoiThongTin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_dlNhanTuForm1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_dtChuyenVeForm1;
        private System.Windows.Forms.Button btn_ChuyenDLForm1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}