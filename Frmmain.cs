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
    public partial class Frmmain : Form
    {
        private string username, usertype;
        public Frmmain(String username, String usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;       
        }

        private void Frmmain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Username:" + username;
            toolStripStatusLabel2.Text = "Usertype:" + usertype;    
        }
    }
}
