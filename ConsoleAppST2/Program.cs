using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ConsoleAppST2
{
    internal class Program
    {
        //string connectionString = "Data Source = THINKPAD\\SQLEXPRESS;" +
        //                            "Initial Catalog = QLSV2;" +
        //                            "Integrated Security = True ";
        
        static void Main(string[] args)
        {
            string connecionString = ConfigurationManager
                            .ConnectionStrings["QLSV_connectionString"]
                            .ConnectionString;
            string maSV, ngaySinh, gioiTinh;

            Console.Write("Nhap ma sinh vien: ");
            maSV = Console.ReadLine();

            while(!KiemTraKhoaChinh_SinhVien(connecionString, maSV))
            {
                Console.Write("Nhap ma lai sinh vien: ");
                maSV = Console.ReadLine();
            }

            Console.Write("Nhap ngay sinh: "); //  "13/12/2000"
            DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
            ngaySinh = dateTime.ToString("yyyy/MM/dd");

            Console.Write("Nhap gioi tinh: "); // nam hoac nu nữ Nữ NỮ
            gioiTinh = Console.ReadLine();

            bool i = ThemSinhVien(connecionString, maSV, ngaySinh, IsGender(gioiTinh));
            if (i)
            {
                Console.WriteLine("Them thanh cong");
            }
            else
            {
                Console.WriteLine("Them khong thanh cong");
            }

            HienThiDanhSachSinhVien(connecionString);
        }

        private static bool IsGender(string gender)
        {
            bool index;
            if( gender.ToLower() == "nam") // Nam NAM 
            {
                index = true;
            }
            else
            {
                index = false;
            }
            return index;
        }

        private static bool ThemSinhVien(string connecionString, string maSV, string ngaySinh, bool gioiTinh)
        {
            //string insert_command = "INSERT INTO tblSINHVIEN (sMaSV, dNgaySinh, bGioiTinh) " +
            //                        "VALUES ('"+maSV+"', '"+ngaySinh+"','"+gioiTinh+"')";
            string insert_proc = "Insert_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connecionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = insert_proc;
                    //khoi tao va truyen cac tham so
                    cmd.Parameters.Add("@maSV", SqlDbType.VarChar, 30).Value = maSV;
                    //cmd.Parameters.AddWithValue("@masv", maSV);
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    return (i > 0);
                }
            }
        }

        private static void HienThiDanhSachSinhVien (string connection)
        {
            string selectSV_proc = "Select_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText=selectSV_proc;
                    cmd.CommandType=CommandType.StoredProcedure;
                    conn.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}",
                                    reader["sMaSV"],
                                    reader["dNgaySinh"],
                                    reader["bGioiTinh"]);
                            }
                        }
                    }
                    conn.Close();
                }
            }
        }

        private static void HienThiDanhSachSinhVienNgatKetNoi(string connectionString)
        {
            string select_pro = "Select_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                //conn.ConnectionString = connectionString;
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select_pro;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using(DataTable dataTable = new DataTable())
                        {
                            adapter.Fill(dataTable);
                            if(dataTable.Rows.Count > 0)
                            {
                                //Hien thi co dieu kien ra man hinh
                                using(DataView dataView = new DataView(dataTable))
                                {
                                    dataView.RowFilter = "bGioiTinh = 'nu'";
                                    dataView.Sort = "dNgaySinh ASC";
                                    //Hien thi ra man hinh
                                    foreach (DataRowView row in dataView)
                                    {
                                        Console.WriteLine("{0}\t{1}",
                                                            row["sMaSV"],
                                                            row["dNgaySinh"]);
                                    }
                                }


                            }
                            else
                            {
                                //khong co ban ghi nao ton tai
                            }
                        }
                    }
                }
            }

        }

        private static bool XoaSinhVienNgatKetNoi(string connectionString, string masv)
        {
            string delete_pro = "Delete_tblSINHVIEN";
            string select_pro = "Select_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select_pro;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using(DataTable dtSINHVIEN = new DataTable("tblSINHVIEN"))
                        {
                            adapter.Fill(dtSINHVIEN) ;
                            using(DataSet dataSet = new DataSet())
                            {
                                //add tung dataTable va dataSet
                                dataSet.Tables.Add(dtSINHVIEN);

                                //tim ma sv can xoa
                                dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["sMaSV"] };
                                DataRow dataRow = dtSINHVIEN.Rows.Find(masv);
                                dataRow.Delete();

                                //dong bo du lieu len Server thong qua DeleteCommand
                                cmd.CommandText = delete_pro;
                                cmd.CommandType= CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@masv", masv);

                                adapter.DeleteCommand = cmd;
                                int i = adapter.Update(dataSet, "tblSINHVIEN");

                                return i>0 ;
                            }
                        }
                    }
                }
            }
        }

        private static bool ThemSinhVienNgatKetNoi(string connectionString, string masv, string ngaysinh)
        {
            string insert_proc = "Insert_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", conn);
                    DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                    adapter.Fill(dtSINHVIEN);

                    //add tung dataTable vao dataSet
                    DataSet dataSet = new DataSet();
                    dataSet.Tables.Add(dtSINHVIEN);

                    //them 1 dong moi vao dataTable
                    DataRow row = dtSINHVIEN.NewRow();
                    row["sMaSV"] = masv;
                    row["dNgaySinh"] = ngaysinh;

                    //dong bo du lieu vao CSDL
                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = insert_proc;
                        cmd.Parameters.AddWithValue("@masv", masv);
                        //.....parameters

                        adapter.InsertCommand = cmd;
                        int i = adapter.Update(dataSet, "tblSINHVIEN");
                        return i>0;
                    }
                }
            }
        }
        private static bool KiemTraKhoaChinh_SinhVien (string connection, string masv)
        {
            string checkID_proc = "KiemTraKhoaChinh_tblSINHVIEN";
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connection;
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    //cmd.Connection= conn;
                    cmd.CommandText = checkID_proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //khoi tao doi tuong Parameter
                    cmd.Parameters.AddWithValue("@maSV", masv);
                    conn.Open();
                    bool i = (cmd.ExecuteScalar() != null); //true-> ma sv da ton tai
                    conn.Close();
                    if(i)
                    {
                        Console.WriteLine("Ma sinh vien: " +masv + " da ton tai!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                    
                }
            }
        }
    }
}
