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
    public partial class CreateNewUserForm : Form
    {
        public CreateNewUserForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateNewUserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String username = usernameTextbox.Text;
            String password = passwordTextbox.Text;
            String usertype = userTypeCombobox.Text;
            String email = emailTextbox.Text;

            int errorCount = 0;

            if (string.IsNullOrEmpty(username))
            {
                errorProvider.SetError(usernameTextbox, "Username is required");
                errorCount++;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorProvider.SetError(passwordTextbox, "Password is required");
                errorCount++;
            }

            if (string.IsNullOrEmpty(usertype))
            {
                errorProvider.SetError(userTypeCombobox, "User type is required");
                errorCount++;
            }

            if (string.IsNullOrEmpty(email))
            {
                errorProvider.SetError(emailTextbox, "Email is required");
                errorCount++;
            }

            Class1 db = new Class1("127.0.0.1", "eteeap-advance-db", "root", "");
            DataTable dt = db.GetData("SELECT * FROM tblaccounts WHERE username = '" + username + "'");

            if (dt.Rows.Count > 0)
            {
                errorProvider.SetError(usernameTextbox, "This username is already been taken");
                errorCount++;
            }

            if (errorCount <= 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to add this account? TESFDFSDTES", "TESTESTSETEST", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (confirmation == DialogResult.Yes)
                {
                    try
                    {
                        db.executeSQL("INSERT INTO tblaccounts (`username`, `password`, `usertype`, `status`, `created_by`) VALUES ('"+username+"', '"+password+"', '"+usertype+"', 'ACTIVE', 'admin')");

                        MessageBox.Show("New account added!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UserAccounts userAccounts = new UserAccounts();
                        userAccounts.Show();
                        this.Close();
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Create acount failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else
            {

            }
        }

        private void showPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckbox.Checked)
            { 
                passwordTextbox.PasswordChar = '\0';
            } else
            {
                passwordTextbox.PasswordChar = '*';
            }
        }
    }
}
