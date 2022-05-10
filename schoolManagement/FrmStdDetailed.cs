using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace schoolManagement
{
    public partial class FrmStdDetailed : Form
    {
        public FrmStdDetailed()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        public string StdID;

        private void FrmStdDetailed_Load(object sender, EventArgs e)
        {
            lblStdID.Text = StdID;

            SqlCommand command = new SqlCommand("Select [Society Name],[Student Name] from Tbl_Student inner join Tbl_Society on Tbl_Student.[Student Society]=Tbl_Society.[Society ID] where [Student ID] =@p1", connector.myConnection());
            command.Parameters.AddWithValue("@p1",lblStdID.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                lblStdName.Text = dataReader[1].ToString();
                lblStdSociety.Text = dataReader[0].ToString();
            }
            connector.myConnection().Close();

            //displaying student's exam results
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Tbl_Course.[Course ID],[Branch Name],Exam#1,Exam#2, Exam#3,Project,[Average Grade],[Is Passed] from Tbl_Grades inner join Tbl_Course on Tbl_Grades.[Course ID] = Tbl_Course.[Course ID] where [Student ID]=" + lblStdID.Text, connector.myConnection());
            dataAdapter.Fill(dataTable);
            dtGridExamResult.DataSource = dataTable;
            dtGridExamResult.Columns[1].Width = 100;
            dtGridExamResult.Columns[0].Width = 25;
            connector.myConnection().Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            FrmAnnouncement announcement = new FrmAnnouncement();
            announcement.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAverageSuccess averageSuccess = new FrmAverageSuccess();
                averageSuccess.branchID = int.Parse(txtBranchID.Text);
                averageSuccess.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("No Course Selected!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dtGridExamResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedValue = dtGridExamResult.SelectedCells[0].RowIndex;
            txtBranchID.Text = dtGridExamResult.Rows[selectedValue].Cells[0].Value.ToString();

        }
    }
}
