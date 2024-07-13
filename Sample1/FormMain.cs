using System;
using System.Linq;
using System.Windows.Forms;

namespace Sample1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var userControlFile = new UserControlFile();
            this.panel1.Controls.Add(userControlFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var userControlRecord = new UserControlRecord();
            this.panel1.Controls.Add(userControlRecord);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var userControlReport = new UserControlReport();
            this.panel1.Controls.Add(userControlReport);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // แสดงกล่องข้อความยืนยัน
            DialogResult result = MessageBox.Show("คุณแน่ใจว่าต้องการปิดแอปพลิเคชัน?", "ยืนยันการปิด", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // ถ้าผู้ใช้เลือก No ให้ยกเลิกการปิด
                e.Cancel = true;
            }
            else
            {
                // ถ้าผู้ใช้เลือก Yes ให้ปิดแอปพลิเคชันทั้งหมด
                //Application.Exit();


                // ถ้าผู้ใช้เลือก Yes ให้ปิดแอปพลิเคชันทั้งหมด
                Environment.Exit(0);
            }
        }
    }
}
