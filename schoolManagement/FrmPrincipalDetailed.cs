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
    public partial class FrmPrincipalDetailed : Form
    {
        public FrmPrincipalDetailed()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        public string principalID;

        private void FrmPrincipalDetailed_Load(object sender, EventArgs e)
        {
            lblPrincipalID.Text = principalID;

            //displaying principal info
            SqlCommand command = new SqlCommand("select * from Tbl_Principal where [Principal ID]=@p1", connector.myConnection());
            command.Parameters.AddWithValue("@p1",lblPrincipalID.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                lblPrincipalName.Text = dataReader[1].ToString();
            }
            connector.myConnection().Close();

            //displaying school info
            SqlCommand command2 = new SqlCommand("select Count(*)from Tbl_Student",connector.myConnection());
            SqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                lblTotalStd.Text = dataReader2[0].ToString();
            }
            connector.myConnection().Close();


            SqlCommand command3 = new SqlCommand("select Count(*)from Tbl_Teacher", connector.myConnection());
            SqlDataReader dataReader3 = command3.ExecuteReader();
            while (dataReader3.Read())
            {
                lblTotalTeacher.Text = dataReader3[0].ToString();
            }
            connector.myConnection().Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            FrmPrincipal_CreateTeacher createTeacher = new FrmPrincipal_CreateTeacher();
            createTeacher.Show();
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Insert into Tbl_Announcement (Announcement) values (@p1)", connector.myConnection());
            command.Parameters.AddWithValue("@p1",richAnnouncement.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Duyuru Oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            richAnnouncement.Text = "";
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            FrmPrincipal_CreateStudent createStudent = new FrmPrincipal_CreateStudent();
            createStudent.Show();
        }
    }
}
