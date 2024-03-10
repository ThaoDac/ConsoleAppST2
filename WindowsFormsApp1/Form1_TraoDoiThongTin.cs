using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1_TraoDoiThongTin : Form, IChuyenDuLieu
    {
        public Form1_TraoDoiThongTin()
        {
            InitializeComponent();
        }

        public void XyLyDuLieu(string value)
        {
            if(value != null)
            {
                tb_dlTraVeTuForm2.Text = value;
            }
            else
            {
                tb_dlTraVeTuForm2.Text = string.Empty;
            }
        }

        private void btn_chuyenForm2_Click(object sender, EventArgs e)
        {
            //Form2_TraoDoiThongTin form2 = new Form2_TraoDoiThongTin(tb_dlChuyenSangForm2.Text);
            Form2_TraoDoiThongTin form2 = new Form2_TraoDoiThongTin(this);
            form2.Show();
        }


    }
}
