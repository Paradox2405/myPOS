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

namespace Sunfairpos
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        dbconnection dbcon = new dbconnection();

        public Form1()
        {

            InitializeComponent();
            conn = new SqlConnection(dbcon.connection());
            conn.Open();
            MessageBox.Show("connection sucessful");
        }

        private void Btnbrand_Click(object sender, EventArgs e)
        {
            managebrands frm = new managebrands();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
