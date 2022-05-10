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
    public partial class FrmPrincipal_CreateStudent : Form
    {
        public FrmPrincipal_CreateStudent()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        void stdList()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select [Student ID],[Student Name],[Society Name],[Student Gender],[Student Password] from Tbl_Student inner join Tbl_Society on Tbl_Student.[Student Society] = Tbl_Society.[Society ID]", connector.myConnection());
            dataAdapter.Fill(dataTable);
            dtGridStudentList.DataSource = dataTable;
            dtGridStudentList.Columns[0].Width = 30;
        }
        void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            cmbSociety.Text = "";
            txtPassword.Text = "";
            cmbGender.Text = "";
            txtName.Focus();
        }

        private void FrmPrincipal_CreateStudent_Load(object sender, EventArgs e)
        {
            stdList();

            SqlCommand command = new SqlCommand("Select * from Tbl_Society",connector.myConnection());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            cmbSociety.DataSource = dataTable;
            cmbSociety.DisplayMember = "Society Name";
            cmbSociety.ValueMember = "Society ID"; 

            connector.myConnection().Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Insert into Tbl_Student ([Student Name], [Student Society],     [Student Gender], [Student Password]) values (@p1,@p2,@p3,@p4)", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtName.Text);
            command.Parameters.AddWithValue("@p2",cmbSociety.Text);
            command.Parameters.AddWithValue("@p3",cmbGender.Text);
            command.Parameters.AddWithValue("@p4",txtPassword.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Kayıt Eklendi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            stdList();
        }

        private void dtGridStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedValue = dtGridStudentList.SelectedCells[0].RowIndex;
            txtID.Text = dtGridStudentList.Rows[selectedValue].Cells[0].Value.ToString();
            txtName.Text = dtGridStudentList.Rows[selectedValue].Cells[1].Value.ToString();
            cmbSociety.Text = dtGridStudentList.Rows[selectedValue].Cells[2].Value.ToString();
            cmbGender.Text = dtGridStudentList.Rows[selectedValue].Cells[3].Value.ToString();
            txtPassword.Text = dtGridStudentList.Rows[selectedValue].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Delete From Tbl_Student where [Student ID]=@p1", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtID.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Kayıt Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            stdList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Tbl_Student set [Student Name]=@p1, [Student Society]=@p2, [Student Gender]=@p3, [Student Password]=@p4 where [Student ID]=@p5", connector.myConnection());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", cmbSociety.Text);
            command.Parameters.AddWithValue("@p3", cmbGender.Text);
            command.Parameters.AddWithValue("@p4", txtPassword.Text);
            command.Parameters.AddWithValue("@p5", txtID.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Kayıt Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            stdList();
        }
    }
}
