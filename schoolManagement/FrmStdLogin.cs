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
    public partial class FrmStdLogin : Form
    {
        public FrmStdLogin()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Student where [Student ID]=@p1 and            [Student Password]=@p2", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtStdID.Text);
            command.Parameters.AddWithValue("@p2",txtStdPassword.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                FrmStdDetailed frmStdDetailed = new FrmStdDetailed();
                frmStdDetailed.StdID = txtStdID.Text;
                frmStdDetailed.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ID veya şifre hatalı!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            connector.myConnection().Close();
        }
    }
}
