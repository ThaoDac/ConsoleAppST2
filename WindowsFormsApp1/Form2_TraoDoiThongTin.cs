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
    public partial class Form2_TraoDoiThongTin : Form
    {
        private IChuyenDuLieu _ichuyendulieu;
        //public Form2_TraoDoiThongTin()
        //{
        //    InitializeComponent();
        //}

        public Form2_TraoDoiThongTin(IChuyenDuLieu ichuyendulieu)
        {
            InitializeComponent();
            this._ichuyendulieu = ichuyendulieu;
        }
        public Form2_TraoDoiThongTin(string value)
        {
            InitializeComponent();
            tb_dlNhanTuForm1.Text = value;
        }

        private void btn_ChuyenDLForm1_Click(object sender, EventArgs e)
        {
            _ichuyendulieu.XyLyDuLieu(tb_dtChuyenVeForm1.Text);
            this.Close();
        }

        private void tb_dtChuyenVeForm1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                _ichuyendulieu.XyLyDuLieu(tb_dtChuyenVeForm1.Text);
                this.Close();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
