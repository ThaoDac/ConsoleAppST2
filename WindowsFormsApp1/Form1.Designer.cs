namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_show_message = new System.Windows.Forms.Button();
            this.btn_trans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_show_message
            // 
            this.btn_show_message.Image = ((System.Drawing.Image)(resources.GetObject("btn_show_message.Image")));
            this.btn_show_message.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_show_message.Location = new System.Drawing.Point(215, 139);
            this.btn_show_message.Name = "btn_show_message";
            this.btn_show_message.Size = new System.Drawing.Size(302, 74);
            this.btn_show_message.TabIndex = 0;
            this.btn_show_message.Text = "Show Message";
            this.btn_show_message.UseVisualStyleBackColor = true;
            this.btn_show_message.Click += new System.EventHandler(this.btn_show_message_Click);
            // 
            // btn_trans
            // 
            this.btn_trans.Location = new System.Drawing.Point(215, 263);
            this.btn_trans.Name = "btn_trans";
            this.btn_trans.Size = new System.Drawing.Size(302, 84);
            this.btn_trans.TabIndex = 1;
            this.btn_trans.Text = "Chuyển sang form 2";
            this.btn_trans.UseVisualStyleBackColor = true;
            this.btn_trans.Click += new System.EventHandler(this.btn_trans_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_trans);
            this.Controls.Add(this.btn_show_message);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_show_message;
        private System.Windows.Forms.Button btn_trans;
    }
}

