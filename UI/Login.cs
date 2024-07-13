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

namespace UI
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=BENDCEMB-LT\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อผู้ใช้และรหัสผ่าน");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM LoginUsers WHERE u_name = @name AND u_pass = @pass ", con);

                    cmd.Parameters.AddWithValue("@name", txtUser.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        int count = ds.Tables[0].Rows.Count;
                        if (count == 1)
                        {
                            //MessageBox.Show("login สำเร็จ");

                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
                        }
                    }
                    
                   
                }

             
            }
            catch(Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }
}
