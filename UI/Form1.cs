using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ต้องการปิดโปรแกรมหรือไม่?", "ยืนยันการปิด", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }

        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();

            //rg.FormClosed += new FormClosedEventHandler(this.Registrations_FormClosed);
            Registration registration = new Registration(this);
            registration.Show();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("ต้องการปิดโปรแกรมหรือไม่?", "ยืนยันการปิด", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // ยกเลิกการปิดฟอร์ม
            }
        }
    }
}
