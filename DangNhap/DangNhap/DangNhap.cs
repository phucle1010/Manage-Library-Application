﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using DangNhap.DAO;
namespace DangNhap
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["CSDL"].ConnectionString;
        private void bntDangNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    string taiKhoan = txtUsernames.Text;
                    string matKhau = txtPass.Text;
                    connection.Open();
                    SHA256 sha256Hash = SHA256.Create();
                    string sql = "select *from UserAccount where TENDN='" + taiKhoan + "'and MATKHAU='" +MaHoa.GetHash(sha256Hash,matKhau)+ "'";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader dataReader = cmd.ExecuteReader();                 
                    if (dataReader.Read())
                    {
                        TaiKhoan tk = new TaiKhoan();
                        tk.setTaiKhoan(taiKhoan);
                        bool check = dataReader.GetBoolean(7);
                        if (check==true)
                        {
                            MessageBox.Show("đăng nhập thành công admin");
                        }
                        else
                            MessageBox.Show("đăng nhập thành công user");
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txtUsernames.Focus();
                        txtUsernames.SelectAll();
                        txtPass.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message,"thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';         
            pictureBox2.Show();
            pictureBox1.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';           
            pictureBox1.Show();
            pictureBox2.Hide();
     
        }
    }
}
