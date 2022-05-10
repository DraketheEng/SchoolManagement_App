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
    public partial class FrmAverageSuccess : Form
    {
        public FrmAverageSuccess()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        public int branchID;

        private void FrmAverageSuccess_Load(object sender, EventArgs e)
        {
            lblBranchID.Text = branchID.ToString();

            SqlCommand graphCommand = new SqlCommand("Select [Is Passed],Count(*) From Tbl_Grades where [Course ID]=@p1 Group By [Is Passed] ", connector.myConnection());
            graphCommand.Parameters.AddWithValue("@p1", int.Parse(lblBranchID.Text));
            SqlDataReader graphDataReader = graphCommand.ExecuteReader();
            while (graphDataReader.Read())
            {
                chart1.Series["Başarı Durumu"].Points.AddXY(graphDataReader[0], graphDataReader[1]);

            }
            connector.myConnection().Close();

            SqlCommand command1 = new SqlCommand("Select Count (*) From Tbl_Grades where [Course ID]=@p1", connector.myConnection());
            command1.Parameters.AddWithValue("@p1", int.Parse(lblBranchID.Text));
            SqlDataReader dataReader1 = command1.ExecuteReader();
            while (dataReader1.Read())
            {
                lblStdCount.Text = dataReader1[0].ToString();
            }
            connector.myConnection().Close();


            SqlCommand command2 = new SqlCommand("Select AVG([Average Grade]) From Tbl_Grades where[Course ID] =@p1", connector.myConnection());
            command2.Parameters.AddWithValue("@p1", int.Parse(lblBranchID.Text));
            SqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                lblAvgGrade.Text = dataReader2[0].ToString();
            }
            connector.myConnection().Close();
            
        }
    }
}
