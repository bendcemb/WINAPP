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

namespace bBear_v2
{
    public partial class usctrDashboard : UserControl
    {
        //private string CompanyName;
        private string conStr;

        private DataTable dataTable; // สำหรับเก็บข้อมูลทั้งหมด
        private int pageSize = 10; // จำนวนแถวต่อหน้า
        private int currentPage = 1; // หน้าปัจจุบัน
        private int totalPage; // จำนวนหน้าทั้งหมด


        public usctrDashboard()
        {

            InitializeComponent();

            // Replace with your actual connection string
            //string conStr = @"Server=C259-003\SQLEXPRESS;Database=KBF;Integrated Security=True;";
            string CompanyName = "TEST";
            //this.conStr = $@"Server=C259-003\SQLEXPRESS;Database={CompanyName};Integrated Security=True;";
            this.conStr = $@"Server=BENDCEMB-LT\SQLEXPRESS;Database={CompanyName};Integrated Security=True;";

            ShowData();
        }

        private void ShowData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    //แสดงตาราง
                    string query = "SELECT A.RO_CODE เลขที่ห้อง, A.RO_DEPT อาคาร, A.RO_OWNER รหัสเจ้าของ , B.PE_NAME FROM CMM_ROOM A LEFT JOIN CMM_CUST B ON A.RO_OWNER = B.PE_CODE";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    da.Fill(dataTable);
                    totalPage = (int)Math.Ceiling(dataTable.Rows.Count / (double)pageSize); // คำนวณจำนวนหน้าทั้งหมด
                    DisplayPage(currentPage);

                    //แสดงจำนวนห้อง
                    string queryCountRoom = "SELECT COUNT(RO_CODE) FROM CMM_ROOM";
                    SqlCommand cmdCountRoom = new SqlCommand(queryCountRoom, con);
                    int roomCount = (int)cmdCountRoom.ExecuteScalar();
                    lblCountRoom.Text = roomCount.ToString("N0");

                    //แสดงจำนวนเจ้าของ
                    string queryCountOwner = "SELECT COUNT(DISTINCT PE_NAME) FROM CMM_CUST";
                    SqlCommand cmdCountOwner = new SqlCommand(queryCountOwner, con);
                    int ownerCount = (int)cmdCountOwner.ExecuteScalar();
                    lblOwner.Text = ownerCount.ToString("N0");

                    //แสดงหนี้ค้างทั้งหมด
                    string querytotalOutstandingDebts = @"SELECT SUM(A.AR_TOTAL) - (SELECT SUM(B.RC_AMOUNT) FROM CMT_RCDL B WHERE B.RC_ARNO IS NOT NULL) FROM CMT_ARHD A;";
                    SqlCommand cmdtotalOutstandingDebts = new SqlCommand(querytotalOutstandingDebts, con);
                    object result = cmdtotalOutstandingDebts.ExecuteScalar();

                    if (result == null)
                    {
                        lblTotalOutstandingDebts.Text = "ไม่พบข้อมูล";
                    }
                    else
                    {
                        decimal totalOutstandingDebts = Convert.ToDecimal(result);
                        lblTotalOutstandingDebts.Text = totalOutstandingDebts.ToString("N2");
                    }

                    //แสดงชำระเดือนปัจจุบัน
                    string queryPaidCurrentMonth = @"SELECT SUM(RC_AMOUNT) AS TotalPaidCurrentMonth FROM CMT_RCDL WHERE RC_ARNO IS NOT NULL AND RC_ARYEAR = (SELECT MAX(RC_ARYEAR) FROM CMT_RCDL WHERE RC_ARNO IS NOT NULL) AND RC_ARMONTH = (SELECT MAX(RC_ARMONTH) FROM CMT_RCDL WHERE RC_ARNO IS NOT NULL AND RC_ARYEAR = (SELECT MAX(RC_ARYEAR) FROM CMT_RCDL WHERE RC_ARNO IS NOT NULL))";
                    SqlCommand cmd2 = new SqlCommand(queryPaidCurrentMonth, con);
                    object result2 = cmd2.ExecuteScalar();

                    if (result2 == DBNull.Value || result2 == null)
                    {
                        lblCurrentMonthCash.Text = "ไม่พบข้อมูล";
                    }
                    else
                    {
                        decimal PaidCurrentMonth = Convert.ToDecimal(result2);
                        lblCurrentMonthCash.Text = PaidCurrentMonth.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ระบบผิดพลาด! : " + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayPage(int page)
        {
            int startIndex = (page - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, dataTable.Rows.Count);

            DataTable pageTable = dataTable.Clone(); // สร้างโครงสร้าง DataTable ใหม่
            for (int i = startIndex; i < endIndex; i++)
            {
                pageTable.ImportRow(dataTable.Rows[i]);
            }

            dtgvDashboard.DataSource = pageTable;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

    }
}
