using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bBear_v2
{
    public partial class FormMain : Form
    {


        // P/Invoke สำหรับการเลื่อนฟอร์ม
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public FormMain()
        {
            InitializeComponent();
            ShowUserControl(ustrDashboard1);


            //// สร้างและตั้งค่า RoundPanel
            //RoundPanel roundPanel = new RoundPanel();
            //roundPanel.Size = new Size(300, 200);
            //roundPanel.Location = new Point(50, 50);
            //roundPanel.BackColor = Color.LightBlue;
            //roundPanel.CornerRadius = 30; // กำหนดรัศมีของขอบโค้ง

            //// เพิ่ม RoundPanel ลงในฟอร์ม
            //this.Controls.Add(roundPanel);

        }

        private void TitleBarpanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
            }
        }


        //Title Controlbox
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.LightGray; // เปลี่ยนสีเมื่อเมาส์อยู่เหนือปุ่ม
                button.ForeColor = Color.Black;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Black; // กลับเป็นสีปกติเมื่อเมาส์ออกจากปุ่ม
                button.ForeColor = Color.Gainsboro;
            }
        }



        private void btnFiles_Click(object sender, EventArgs e)
        {
           
            usctrFile1 = new usctrFile();
            ShowUserControl(usctrFile1);

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
            ustrDashboard1 = new usctrDashboard();
            ShowUserControl(ustrDashboard1);
        }

        private void ShowUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            usctrRecord1 = new usctrRecordBy();
            ShowUserControl(usctrRecord1);
        }
    }
}
