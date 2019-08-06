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
    public partial class categorylists : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        SqlDataReader dr;
        public categorylists()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.connection());
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void loadItems()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            conn.Open();
            comm = new SqlCommand("SELECT * FROM tblitems ORDER BY item_code", conn);
            dr = comm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["item_name"].ToString(), dr["item_code"].ToString(), dr["quantity"].ToString());
            }
            dr.Close();
            conn.Close();

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory(this);
            //frm.btnsave.Enabled = true;


            frm.ShowDialog();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                frmCategory frm = new frmCategory(this);
                frm.txtName.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                frm.txtQuantity.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                frm.txtId.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                //frm.btnSave.Enabled = false;
                //frm.btnUpdate.Enabled = true;
                frm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    comm = new SqlCommand("delete from tblitems where id like '" + dataGridView1[1, e.RowIndex].Value.ToString() + "'", conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record has been deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadItems();

                }
            }

        }
    }    
}
