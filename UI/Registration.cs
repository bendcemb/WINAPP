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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace UI
{
    public partial class Registration : Form
    {
        //string Connection
        string path = @"Data Source=BENDCEMB-LT\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        System.Data.DataTable dt;
        int ID;
        private Form1 mainForm;
        private Timer timer;



        public Registration(Form1 form1)
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            this.mainForm = form1;
            this.FormClosing += new FormClosingEventHandler(Registration_FormClosing);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrWhiteSpace(txtDesign.Text) || string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("กรุณาเติมข้อมูลให้ครบ");
            }
            else
            {
                try
                {
                    string gender;

                    if (rbtnMale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Femele";
                    }

                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Employees (emp_name, fname, desgination, email, id, gender, emp_address) " +
                                 "VALUES (@emp_name, @fname, @desgination,@email, @id, @gender, @emp_address)", con);

                    // เพิ่มพารามิเตอร์และค่าที่ต้องการ
                    cmd.Parameters.AddWithValue("@emp_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@fname", txtFName.Text);
                    cmd.Parameters.AddWithValue("@desgination", txtDesign.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@emp_address", txtAddress.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("บันทึกเรียบร้อยแล้ว");

                    lblResult.Text = "บันทึกสำเร็จ";

                    if (timer == null)
                    {
                        timer = new Timer();
                        timer.Interval = 10000;
                        timer.Tick += Timer_Tick;
                    }
                    timer.Start();
                    
                    clear();
                    display();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            timer.Stop();
        }

        public void clear()
        {
            txtName.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtDesign.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtID.Text = string.Empty;
            txtAddress.Text = string.Empty;

        }

        public void display()
        {
            try
            {
                dt = new System.Data.DataTable();
                con.Open();
                adapter = new SqlDataAdapter("SELECT * FROM Employees", con);
                adapter.Fill(dt);
                grv1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            ID = int.Parse(grv1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = grv1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtFName.Text = grv1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDesign.Text = grv1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = grv1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtID.Text = grv1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //gender = grv1.Rows[e.RowIndex].Cells[6].Value.ToString();


            rbtnMale.Checked = true;
            rbtnFemale.Checked = false;

            if (grv1.Rows[e.RowIndex].Cells[6].Value.ToString() == "Femele")
            {
                rbtnMale.Checked = false;
                rbtnFemale.Checked = true;
            }

            txtAddress.Text = grv1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string gender;
                if (rbtnMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                cmd = new SqlCommand("UPDATE Employees SET " +
                    "emp_name = '" + txtName.Text + "'," +
                    "fname = '" + txtFName.Text + "'," +
                    "desgination = '" + txtDesign.Text + "'," +
                    "email = '" + txtEmail.Text + "'," +
                    "id = '" + txtID.Text + "'," +
                    "gender = '" + gender + "'," +
                    "emp_address = '" + txtAddress.Text + "'" +
                    " WHERE emp_id = '" + ID + "'" +
                    " ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Complet!!");
                display();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณแน่ใจว่าต้องการลบข้อมูลนี้หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();

                    cmd = new SqlCommand("DELETE FROM Employees WHERE emp_id = @emp_id", con);
                    cmd.Parameters.AddWithValue("@emp_id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                    lblResult.Text = "ลบข้อมูลเรียบร้อยแล้ว";
                    if (timer == null)
                    {
                        timer = new Timer();
                        timer.Interval = 10000;
                        timer.Tick += Timer_Tick;
                    }
                    timer.Start();

                    display();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {

            mainForm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();



            adapter = new SqlDataAdapter("SELECT * FROM Employees WHERE emp_name LIKE '%" + 
                txtSearch.Text + "%' OR emp_id LIKE '%"+ txtSearch.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adapter.Fill(dt);
            grv1.DataSource = dt;

            con.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            try
            {
                Excel.Application ExcelApp = new Excel.Application();
                Excel.Workbook wb = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
                ExcelApp.Visible = true;

                // เขียนหัวข้อคอลัมน์
                for (int i = 1; i <= grv1.Columns.Count; i++)
                {
                    ws.Cells[1, i] = grv1.Columns[i - 1].HeaderText;
                }

                // เขียนข้อมูลจาก DataGridView
                for (int j = 0; j < grv1.Rows.Count; j++)
                {
                    for (int i = 0; i < grv1.Columns.Count; i++)
                    {
                        object cellValue = grv1.Rows[j].Cells[i].Value;
                        if (cellValue != null)
                        {
                            ws.Cells[j + 2, i + 1] = cellValue.ToString();
                        }
                        else
                        {
                            // ใส่ค่าเริ่มต้นหรือปรับแต่งตามที่ต้องการ
                            ws.Cells[j + 2, i + 1] = "";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
