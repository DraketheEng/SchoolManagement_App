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
    public partial class FrmTeacherDetailed : Form
    {
        public FrmTeacherDetailed()
        {
            InitializeComponent();
        }

        public string teacherID;

        sqlConnector connector = new sqlConnector();

        void examResults()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("Select Tbl_Grades.[Student ID], [Branch Name], [Student Name], Exam#1,Exam#2, Exam#3, Project, [Average Grade], [Is Passed] from Tbl_Grades inner join Tbl_Course on Tbl_Grades.[Course ID] = Tbl_Course.[Course ID] inner join Tbl_Student on Tbl_Grades.[Student ID] = Tbl_Student.[Student ID] where Tbl_Course.[Course ID]=@p1", connector.myConnection());
            sqlCommand.Parameters.AddWithValue("@p1", byte.Parse(lblBrachID.Text));
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dtGridStudentList.DataSource = dataTable;
            dtGridStudentList.Columns[0].Width = 30;
            dtGridStudentList.Columns[1].Width = 100;
            dtGridStudentList.Columns[2].Width = 100;
        }

        void clear()
        {
            txtStdID.Text = "";
            txt1stExam.Text = "";
            txt1stExam.Focus();
            txt2ndExam.Text = "";
            txt3rdExam.Text = "";
            txtProject.Text = "";
        }

        private void FrmTeacherDetailed_Load(object sender, EventArgs e)
        {
            lblTeacherID.Text = teacherID;

            //displaying teacher info
            SqlCommand command = new SqlCommand("Select [Branch Name],[Teacher Name], [Course ID] from Tbl_Teacher inner join Tbl_Course on Tbl_Teacher.[Teacher Branch] = Tbl_Course.[Course ID] where [Teacher ID]=@p1", connector.myConnection());
            command.Parameters.AddWithValue("@p1",lblTeacherID.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                lblTeacherName.Text = dataReader[1].ToString();
                lblTeacherBranch.Text = dataReader[0].ToString();
                lblBrachID.Text = dataReader[2].ToString();
            }
            connector.myConnection().Close();

            //displaying student exam info
            examResults();

        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            FrmAnnouncement announcement = new FrmAnnouncement();
            announcement.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtGridStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedValue = dtGridStudentList.SelectedCells[0].RowIndex;
            txtStdID.Text = dtGridStudentList.Rows[selectedValue].Cells[0].Value.ToString();
            txt1stExam.Text = dtGridStudentList.Rows[selectedValue].Cells[3].Value.ToString();
            txt2ndExam.Text = dtGridStudentList.Rows[selectedValue].Cells[4].Value.ToString();
            txt3rdExam.Text = dtGridStudentList.Rows[selectedValue].Cells[5].Value.ToString();
            txtProject.Text = dtGridStudentList.Rows[selectedValue].Cells[6].Value.ToString();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Insert into Tbl_Announcement (Announcement) values (@p1)", connector.myConnection());
            command.Parameters.AddWithValue("@p1",richAnnouncement.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Duyuru oluşturuldu!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            richAnnouncement.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Tbl_Grades set Exam#1=@p1, Exam#2=@p2, Exam#3=@p3, Project=@p4, [Average Grade]=@p5, [Is Passed]=@p6 where [Student ID]=@p7 and [Course ID] = @p8",  connector.myConnection());
            command.Parameters.AddWithValue("@p1",txt1stExam.Text);
            command.Parameters.AddWithValue("@p2",txt2ndExam.Text);
            command.Parameters.AddWithValue("@p3",txt3rdExam.Text);
            command.Parameters.AddWithValue("@p4",txtProject.Text);

            double exam1, exam2, exam3, project;
            double average;
            bool isPassed;
            exam1 = Convert.ToDouble(txt1stExam.Text);
            exam2 = Convert.ToDouble(txt2ndExam.Text);
            exam3 = Convert.ToDouble(txt3rdExam.Text);
            project = Convert.ToDouble(txtProject.Text);
            average = (exam1 + exam2 + exam3 + project) / 4.00;

            if (average >= 50)
            {
                isPassed = true;
            }
            else
            {
                isPassed = false;
            }

            command.Parameters.AddWithValue("@p5", average);
            command.Parameters.AddWithValue("@p6", isPassed);
            command.Parameters.AddWithValue("@p7",txtStdID.Text);
            command.Parameters.AddWithValue("@p8", byte.Parse(lblBrachID.Text));
            

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            examResults();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select Tbl_Grades.[Student ID], [Branch Name], [Student Name], Exam#1,Exam#2, Exam#3, Project, [Average Grade], [Is Passed] from Tbl_Grades inner join Tbl_Course on Tbl_Grades.[Course ID] = Tbl_Course.[Course ID] inner join Tbl_Student on Tbl_Grades.[Student ID] = Tbl_Student.[Student ID] where [Student Name] like '%" + txtSearch.Text + "%' ",connector.myConnection());
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            dtGridStudentList.DataSource = dataTable;

            connector.myConnection().Close();

        }
    }
}
