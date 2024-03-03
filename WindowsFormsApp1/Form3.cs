using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool gioiTinh;
        private string connectionString =
            ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

        private DataTable dtSINHVIEN = new DataTable();
        private DataView dvSINHVIEN = new DataView();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {
            string queryStr = "SELECT_tblSINHVIEN";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dtSINHVIEN);
                        if (dtSINHVIEN.Rows.Count > 0)
                        {
                            dvSINHVIEN = dtSINHVIEN.DefaultView;
                            dgv_dssv.AutoGenerateColumns = false;
                            dgv_dssv.DataSource = dvSINHVIEN;
                        }
                        else
                        {
                            MessageBox.Show("Khong co ban ghi nao ton tai");
                        }
                    }
                }
            }
        }

        //private void tb_hoten_TextChanged(object sender, EventArgs e)
        //{
        //    if(this.tb_hoten.Text.Length > 0)
        //    {
        //        btn_them.Enabled = true;
        //    }
        //    else 
        //    { 
        //        btn_them.Enabled = false; 
        //    }
        //}

        //private void tb_hoten_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(tb_hoten.Text))
        //    {
        //        //e.Cancel = true;
        //        errorProvider.SetError(tb_hoten, "Họ và tên sinh viên không được để trống");

        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider.SetError(tb_hoten, null);
        //    }
        //}

        //kiem tra ky tu trong 1 chuoi
        private bool IsNumber(string strValue)
        {
            foreach (Char ch in strValue)
            {
                if (!Char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        //private void tb_sdt_TextChanged(object sender, EventArgs e)
        //{
        //    if (!IsNumber(tb_sdt.Text))
        //    {
        //        btn_them.Enabled = false;
        //        errorProvider.SetError(tb_sdt, "Số điện thoại phải là số");
        //    }
        //    else
        //    {
        //        btn_them.Enabled = true;
        //        errorProvider.SetError (tb_sdt, null);
        //    }
        //}

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tb_mssv.Focus();
        }

        private void Form3_Move(object sender, EventArgs e)
        {
            tb_mssv.Focus();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (rb_nam.Checked == true)
            {
                gioiTinh = true;
            }
            else if (rb_nu.Checked == true)
            {
                gioiTinh = false;
            }

            //phương thức kiểm tra sự tồn tại của khóa chính
            string idsv = tb_mssv.Text;

            //Them dữ liệu mới vào CSDL theo pp ngắt kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select_tblSINHVIEN";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable dt_tblSINHVIEN = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(dt_tblSINHVIEN);
                            using (DataSet dataSet = new DataSet())
                            {
                                //add tung datatable vao dataset
                                dataSet.Tables.Add(dt_tblSINHVIEN);

                                //Them ban ghi moi vao dataTable
                                DataRow newRow = dt_tblSINHVIEN.NewRow();
                                newRow["sMaSV"] = tb_mssv.Text.Trim();
                                newRow["dNgaySinh"] = dt_ngaySinh.Value.ToString("yyyy/MM/dd");
                                newRow["bGioiTinh"] = gioiTinh;
                                //dien day du cac truong du lieu cho phan thong tin sv
                                dt_tblSINHVIEN.Rows.Add(newRow);

                                //them ban ghi thong qua InsertCommand
                                cmd.CommandText = "Insert_tblSINHVIEN";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.
                                    Add("@masv", SqlDbType.VarChar, 30, "sMaSV").Value = tb_mssv.Text;
                                cmd.Parameters.AddWithValue("@ngaysinh", dt_ngaySinh.Value.ToString("yyyy/MM/dd"));
                                cmd.Parameters.AddWithValue("@gioitinh", gioiTinh);

                                adapter.InsertCommand = cmd;
                                adapter.Update(dataSet, "tblSINHVIEN");

                                MessageBox.Show("Them moi thanh cong");
                                //thuc hien phuong thuc Load lai du lieu len tren giao dien
                            }
                        }
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (rb_nam.Checked == true)
            {
                gioiTinh = true;
            }
            else
            {
                gioiTinh = false;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT_tblSINHVIEN";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dtSINHVIEN = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(dtSINHVIEN);
                            using (DataSet dataSet = new DataSet())
                            {
                                dataSet.Tables.Add(dtSINHVIEN);
                                //chinh sua du lieu trong dataTable
                                dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["sMaSV"] };
                                DataRow row = dtSINHVIEN.Rows.Find(tb_mssv.Text);
                                row["dNgaySinh"] = dt_ngaySinh.Value.ToString("yyyy/MM/dd");
                                row["bGioiTinh"] = gioiTinh;
                                //cac truong du lieu khac

                                //thuc hien updateCommand
                                cmd.CommandText = "Update_tblSINHVIEN";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@masv", tb_mssv.Text);
                                //...
                                adapter.UpdateCommand = cmd;
                                adapter.Update(dataSet, "tblSINHVIEN");

                                MessageBox.Show("Chinh sua thanh cong");
                                //thuc hien phuong thuc load lai du lieu
                            }
                        }
                    }
                }
            }
        }

        private void dgv_dssv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_dssv.CurrentRow.Index;
            //chuyen du lieu tu dgv len cac dieu khien tuong ung
            //tb_mssv.Text = dgv_dssv.Rows[index].Cells["MaSV"].Value.ToString();
            //tb_mssv.Text = dtSINHVIEN.Rows[index]["sMaSV"].ToString();
            tb_mssv.Text = dvSINHVIEN[index]["sMaSV"].ToString();
            tb_mssv.ReadOnly = true;
            dt_ngaySinh.Text = dvSINHVIEN[index]["dNgaySinh"].ToString();

            if ((bool)(dvSINHVIEN[index]["bGioiTinh"]) == true)
            {
                rb_nam.Checked = true;
            }
            else
            {
                rb_nu.Checked = true;
            }
        }
    }
}
