using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311ETEEAP2023_A
{
    public partial class UserAccounts : Form
    {
        public UserAccounts()
        {
            InitializeComponent();
        }

        private void UserAccounts_Load(object sender, EventArgs e)
        {
            Class1 db = new Class1("127.0.0.1", "eteeap-advance-db", "root", "");
            DataTable dt = db.GetData("SELECT username, usertype, `status`, created_by FROM tblaccounts WHERE status =  'ACTIVE'");

            dataGridView1.DataSource = dt;
        }

        private void userSearchBox_TextChanged(object sender, EventArgs e) 
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 db = new Class1("127.0.0.1", "eteeap-advance-db", "root", "");
            DataTable dt = db.GetData("SELECT username, usertype, `status`, created_by FROM tblaccounts WHERE status =  'ACTIVE' AND username LIKE '%" + userSearchBox.Text + "%'");

            dataGridView1.DataSource = dt;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateNewUserForm createNewUserForm = new CreateNewUserForm();
            createNewUserForm.Show();
            this.Hide();
        }

        private int row = 1;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dialogResult == DialogResult.Yes)
            {
                string selecteduser = dataGridView1.Rows[row].Cells[0].Value.ToString();

                try
                {
                    Class1 db = new Class1("127.0.0.1", "eteeap-advance-db", "root", "");
                    db.executeSQL("DELETE FROM tblaccounts WHERE username = '" + selecteduser + "'");

                    button1_Click(sender, e);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot delete user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
