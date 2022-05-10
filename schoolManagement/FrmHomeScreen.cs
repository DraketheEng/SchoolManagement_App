using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolManagement
{
    public partial class FrmHomeScreen : Form
    {
        public FrmHomeScreen()
        {
            InitializeComponent();
        }

        private void picStdLogin_Click(object sender, EventArgs e)
        {
            FrmStdLogin frmStdLogin = new FrmStdLogin();
            frmStdLogin.Show();
            this.Hide();
        }

        private void picTeacherLogin_Click(object sender, EventArgs e)
        {
            FrmTeacherLogin frmTeacherLogin = new FrmTeacherLogin();
            frmTeacherLogin.Show();
            this.Hide();
        }

        private void picPrincipalLogin_Click(object sender, EventArgs e)
        {
            FrmPrincipalLogin frmPrincipalLogin = new FrmPrincipalLogin();
            frmPrincipalLogin.Show();
            this.Hide();
        }
    }
}
