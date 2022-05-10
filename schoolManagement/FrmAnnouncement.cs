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
    public partial class FrmAnnouncement : Form
    {
        public FrmAnnouncement()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();
        private void FrmAnnouncement_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Tbl_Announcement", connector.myConnection());
            dataAdapter.Fill(dataTable);
            dtGridAnnouncement.DataSource = dataTable;
            dtGridAnnouncement.Columns[0].Width = 30;
        }
    }
}
