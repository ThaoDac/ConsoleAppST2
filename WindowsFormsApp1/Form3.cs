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
using System.Runtime.InteropServices;

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

        private void LoadDataToGridView(string filter = "")
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
                            if (filter != null)
                            {
                                dvSINHVIEN.RowFilter = filter;
                            }
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int index = dgv_dssv.CurrentRow.Index;
            string masv = dvSINHVIEN[index]["sMaSV"].ToString();

            try
            {
                //Kiem tra rang buoc giua cac bang du lieu
                KiemTraRangBuoc_BangDiem(masv);

                //neu khong co rang buoc thi moi cho xoa
                DialogResult dialogResult = MessageBox.Show("Co muon xoa ma sinh vien " + masv + " khong?",
                    "Canh bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            //lay danh sach sv vao Datatable
                            adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", conn);
                            DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                            adapter.Fill(dtSINHVIEN);

                            //add cac datatable vao dataset
                            DataSet ds = new DataSet();
                            ds.Tables.Add(dtSINHVIEN);

                            //tim masv can xoa
                            dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["sMaSV"] };
                            DataRow dataRow = dtSINHVIEN.Rows.Find(masv);
                            dataRow.Delete();

                            //xoa du lieu trong DB
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = "Delete_tblSINHVIEN";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@masv", masv);

                                adapter.DeleteCommand = cmd;
                                adapter.Update(ds, "tblSINHVIEN");
                            }
                        }
                    }
                }
                else
                {
                    return;
                }

                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                if (error.Contains(masv))
                {
                    MessageBox.Show("Ma sinh vien " + masv + " da phat sinh diem");
                }
                else if (error.Contains("40"))
                {
                    MessageBox.Show("Loi ket noi SQL");
                }
                else
                {
                    MessageBox.Show("Da co loi xay ra");
                }
            }
            
            LoadDataToGridView();
        }

        private void KiemTraRangBuoc_BangDiem (string masv)
        {
            //kiem tra masv co ton tai tai bang Diem
            using(SqlConnection conn = new SqlConnection (connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand ())
                {
                    cmd.CommandText = "KiemTraMaSV_BangDiem";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@masv", masv);
                    conn.Open ();
                    bool i = cmd.ExecuteScalar() != null; 
                    conn.Close ();

                    if(i)
                    {
                        throw new Exception("Ma sinh vien " + masv + " da co phat sinh diem");
                    }
                }
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string filter = "sMaSV IS NOT NULL";
            if(tb_mssv.Text != null)
            {
                filter += string.Format(" AND sMaSV LIKE '%{0}%'", tb_mssv.Text);
            }
            //if (!string.IsNullOrEmpty(dt_ngaySinh.Value.ToString()))
            //{
            //    filter += string.Format(" AND dNgaySinh LIKE '%{0}%'", dt_ngaySinh.Value.ToString());
            //}
            //..cac truong du lieu khac tuong ung voi cac control
            LoadDataToGridView(filter);
        }
    }
}
