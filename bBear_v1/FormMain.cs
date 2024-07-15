using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bBear_v1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //userControlFile1.Visible = false;
            //userControlRecord1.Visible = false;
        }

        //private void FormMain_Load(object sender, EventArgs e)
        //{
        //    // Hide UserControls initially
        //    userControlFile1.Visible = false;
        //    userControlRecord1.Visible = false;
        //}

        private void btnFile_Click(object sender, EventArgs e)
        {
            // Show UserControlFile and hide UserControlRecord
            //userControlFile1.Visible = true;
            //userControlRecord1.Visible = false;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            // Show UserControlRecord and hide UserControlFile
            //userControlFile1.Visible = false;
            //userControlRecord1.Visible = true;
        }
    }
}
