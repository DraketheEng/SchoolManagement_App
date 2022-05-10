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
    public partial class FrmPrincipalLogin : Form
    {
        public FrmPrincipalLogin()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Principal where [Principal ID]=@p1 and [Principal Password]=@p2", connector.myConnection());
            command.Parameters.AddWithValue("@p1", txtPrincipalID.Text);
            command.Parameters.AddWithValue("@p2", txtPrincipalPassword.Text);
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.Read())
            {
                FrmPrincipalDetailed frmPrincipalDetailed = new FrmPrincipalDetailed();
                frmPrincipalDetailed.principalID = txtPrincipalID.Text;
                frmPrincipalDetailed.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ID veya Şifre Hatalı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connector.myConnection().Close();
        }
    }
}
