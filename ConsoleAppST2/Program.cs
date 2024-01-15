using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string insert_command = "INSERT INTO tblSINHVIEN (sMaSV, dNgaySinh, bGioiTinh) " +
                                    "VALUES ('"+maSV+"', '"+ngaySinh+"','"+gioiTinh+"')";
            using(SqlConnection conn = new SqlConnection(connecionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = insert_command;

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    return (i > 0);
                }
            }
        }
    }
}
