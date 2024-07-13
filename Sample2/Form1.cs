using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample2
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();

        string name;
        string designation;
        int salary;
        string gender;
        string review;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            
            name = txtName.Text;
            designation = txtDesignation.Text;
            salary = int.Parse(txtSalary.Text);

           

            if(rbtnMale.Checked)
            {
                gender = "ผู้ชาย";
            }
            else
            {
                gender = "ผู้หญิง";
            }

            if(chkGood.Checked)
            {
                review = "Good";
            }
            else
            {
                review = "Very Good";
            }
            display();
            empty();
            //lblDisplay.Text = " คุณ :" + name + " ตำแหน่่ง : " + designation + " เงินเดือน : " + salary + " เพศ :" + gender + " " + review;

        }

        public void display()
        {
            dt.Columns.Add(" Name ");
            dt.Columns.Add(" Designation ");
            dt.Columns.Add(" Salary ");
            dt.Columns.Add(" Genger ");
            dt.Columns.Add(" Review ");
            
            DataRow dr = dt.NewRow();
            dr[0] = name;
            dr[1] = designation;
            dr[2] = salary;
            dr[3] = gender;
            dr[4] = review;

            dt.Rows.Add(dr);
            grvData.DataSource = dt;
           
        }

        public void empty()
        {
            txtDesignation.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSalary.Text = string.Empty;
            
        }
    }
}
