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
    public partial class FrmPrincipal_CreateTeacher : Form
    {
        public FrmPrincipal_CreateTeacher()
        {
            InitializeComponent();
        }

        sqlConnector connector = new sqlConnector();

        void TeacherList()
        {
            //displaying teacher info (in datagrid)
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select [Teacher ID],[Teacher Name],[Branch Name],[Teacher Password] from Tbl_Teacher inner join Tbl_Course on Tbl_Teacher.[Teacher Branch] = Tbl_Course.[Course ID]", connector.myConnection());
            dataAdapter.Fill(dataTable);
            dtGridTeacherList.DataSource = dataTable;
            dtGridTeacherList.Columns[0].Width = 30;
        }

        void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            cmbBranch.Text = "";
            txtPassword.Text = "";
            txtName.Focus();
        }

        private void FrmPrincipal_CreateTeacher_Load(object sender, EventArgs e)
        {
            TeacherList();

            SqlCommand command = new SqlCommand("select * from Tbl_Course", connector.myConnection());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            cmbBranch.DataSource = dataTable;
            cmbBranch.DisplayMember = "Branch Name";
            cmbBranch.ValueMember = "Course ID";

            connector.myConnection().Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Insert into Tbl_Teacher ([Teacher Name], [Teacher Branch], [Teacher Password]) values (@p1,@p2,@p3)", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtName.Text);
            command.Parameters.AddWithValue("@p2",cmbBranch.Text);
            command.Parameters.AddWithValue("@p3",txtPassword.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Kayıt Oluşturuldu!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            TeacherList();
        }

        private void dtGridTeacherList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedValue = dtGridTeacherList.SelectedCells[0].RowIndex;
            txtID.Text = dtGridTeacherList.Rows[selectedValue].Cells[0].Value.ToString();
            txtName.Text = dtGridTeacherList.Rows[selectedValue].Cells[1].Value.ToString();
            cmbBranch.Text = dtGridTeacherList.Rows[selectedValue].Cells[2].Value.ToString();
            txtPassword.Text = dtGridTeacherList.Rows[selectedValue].Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Delete from Tbl_Teacher where [Teacher ID]=@p1", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtID.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Kayıt Silindi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            TeacherList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Tbl_Teacher set [Teacher Name]=@p1, [Teacher Branch]=@p2, [Teacher Password]=@p3 where [Teacher ID]=@p4", connector.myConnection());
            command.Parameters.AddWithValue("@p1",txtName.Text);
            command.Parameters.AddWithValue("@p2",cmbBranch.Text);
            command.Parameters.AddWithValue("@p3",txtPassword.Text);
            command.Parameters.AddWithValue("@p4",txtID.Text);

            command.ExecuteNonQuery();
            connector.myConnection().Close();

            MessageBox.Show("Kayıt Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TeacherList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
