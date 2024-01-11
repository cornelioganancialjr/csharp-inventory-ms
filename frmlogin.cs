using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311ETEEAP2023_A
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        Class1 login = new Class1("127.0.0.1", "eteeap-advance-db", "root", "");
       
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = login.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "' AND password = '" +
                    txtpassword.Text + "' AND status =  'ACTIVE'");

                if (dt.Rows.Count > 0)
                {
                    Frmmain mainfrm = new Frmmain(txtusername.Text, dt.Rows[0].Field<string>("usertype"));
                    mainfrm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Incorrect login credentials or account is inactive", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnlogin_click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked) 
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToChar(e.KeyChar) == 13) 
            {
                btnlogin_Click(sender, e);  
            }
        }
    }
}
