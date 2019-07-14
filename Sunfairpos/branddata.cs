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
    public partial class branddata : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        managebrands frmlist;
        public branddata(managebrands flist)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.connection());
            frmlist = flist;
            
        }

        private void Branddata_Load(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            btnsave.Enabled = true;
            btnupdate.Enabled = false;
            txtbrand.Clear();
            txtbrand.Focus();

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to add this brand?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    conn.Open();
                    comm = new SqlCommand("INSERT INTO tblbrand(Brand) VALUES (@brand)", conn);
                    comm.Parameters.AddWithValue("@brand", txtbrand.Text);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Sucessfully added!");
                    clear();
                    frmlist.loadrecords();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
