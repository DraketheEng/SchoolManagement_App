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
    public partial class FrmTeacherLogin : Form
    {
        public FrmTeacherLogin()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Teacher where [Teacher ID]=@p1 and [Teacher Password]=@p2", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtTeacherID.Text);
            command.Parameters.AddWithValue("@p2",txtTeacherPassword.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                FrmTeacherDetailed frmTeacherDetailed = new FrmTeacherDetailed();
                frmTeacherDetailed.teacherID = txtTeacherID.Text;
                frmTeacherDetailed.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ID veye Şifre Hatalı!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            connector.myConnection().Close();
        }
    }
}
