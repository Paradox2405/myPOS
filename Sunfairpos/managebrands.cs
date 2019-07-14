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
    public partial class managebrands : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        SqlDataReader dr;
        dbconnection dbcon = new dbconnection();

        public managebrands()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.connection());
            loadrecords();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            branddata frm = new branddata(this);
            frm.ShowDialog();
        }

        public void loadrecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            conn.Open();
            comm = new SqlCommand("SELECT * FROM tblbrand ORDER BY brand", conn);
            dr = comm.ExecuteReader();
            while(dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["id"].ToString(),dr["brand"].ToString());
            }
            dr.Close();
            conn.Close();

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Managebrands_Load(object sender, EventArgs e)
        {

        }
    }
}
