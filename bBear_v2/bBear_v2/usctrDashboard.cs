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
        // Replace with your actual connection string
        //string conStr = @"Server=C259-003\SQLEXPRESS;Database=KBF;User Id=BNN\thinnarut;Password=mboit;";
        string conStr = @"Server=C259-003\SQLEXPRESS;Database=KBF;Integrated Security=True;";

        private DataTable dataTable; // สำหรับเก็บข้อมูลทั้งหมด
        private int pageSize = 10; // จำนวนแถวต่อหน้า
        private int currentPage = 1; // หน้าปัจจุบัน
        private int totalPage; // จำนวนหน้าทั้งหมด


        public usctrDashboard()
        {
            InitializeComponent();

            DataGridviewDashboard();
            CountRoom();
            CountOwner();
            TotalOutstandingDebts();

        }

        private void DataGridviewDashboard()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string query = "SELECT A.RO_CODE เลขที่ห้อง, A.RO_DEPT อาคาร, A.RO_OWNER รหัสเจ้าของ , B.PE_NAME  " +
                        "FROM CMM_ROOM A " +
                        "LEFT JOIN CMM_CUST B " +
                        "ON A.RO_OWNER = B.PE_CODE";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    da.Fill(dataTable);

                    // คำนวณจำนวนหน้าทั้งหมด
                    totalPage = (int)Math.Ceiling(dataTable.Rows.Count / (double)pageSize);

                    DisplayPage(currentPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ระบบผิดพลาด! : " + ex.Message);
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

        private void CountRoom()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    con.Open();
                    string query = "SELECT COUNT(RO_CODE) FROM CMM_ROOM";
                    SqlCommand cmd = new SqlCommand(query, con);

                    int roomCount = (int)cmd.ExecuteScalar();

                    lblCountRoom.Text = roomCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ระบบผิดพลาด ? : " + ex.Message, "Error");
            }
        }

        private void CountOwner()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string query = "SELECT COUNT(DISTINCT PE_NAME) FROM CMM_CUST";
                    SqlCommand cmd = new SqlCommand(query, con);

                    int ownerCount = (int)cmd.ExecuteScalar();

                    lblOwner.Text = ownerCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ระบบผิดพลาด!! :" + ex.Message);
            }
        }

        private void TotalOutstandingDebts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string query = "SELECT \r\n    SUM(A.AR_TOTAL) AS รวมแจ้งหนี้,\r\n    (SELECT SUM(B.RC_AMOUNT) FROM [KBF].[dbo].[CMT_RCDL] B WHERE B.RC_ARNO IS NOT NULL) AS รวมชำระใบแจ้งหนี้,\r\n\tSUM(A.AR_TOTAL) - (SELECT SUM(B.RC_AMOUNT) FROM [KBF].[dbo].[CMT_RCDL] B WHERE B.RC_ARNO IS NOT NULL) AS รวมค้างชำระ\r\nFROM  [KBF].[dbo].[CMT_ARHD] A;";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        decimal totalInvoices = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        decimal totalPayments = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                        decimal totalOutstandingDebts = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);

                        // Update the label text
                        lblTotalOutstandingDebts.Text = totalOutstandingDebts.ToString("N2");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ระบบผิดพลาด!! :" + ex.Message);
            }
        }

    }
}
