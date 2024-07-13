using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name;

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCouse.Items.Add(" C# Programing ");
            cmbCouse.Items.Add(" C++ Programing ");
            cmbCouse.Items.Add(" C Programing ");
            cmbCouse.Items.Add(" Java Programing ");
            cmbCouse.Items.Add(" PHP Programing ");
        }

        private void cmbCouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = cmbCouse.SelectedItem.ToString();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(name);
        }
    }
}
