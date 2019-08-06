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
    public partial class frmCategory : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        categorylists flist;

        public frmCategory(categorylists frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.connection());
            flist = frm;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            btnsave.Enabled = true;
            btnupdate.Enabled = false;
            txtName.Clear();
            txtName.Focus();
            txtId.Clear();
            txtQuantity.Clear();

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Are you sure you want to add this Item?", "Saving Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    conn.Open();
                    comm = new SqlCommand("INSERT INTO tblitems(item_code,item_name,quantity) VALUES (@item_code,@item_name,@quantity)", conn);
                    comm.Parameters.AddWithValue("@item_code", txtId.Text);
                    comm.Parameters.AddWithValue("@item_name", txtName.Text);
                    comm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Item Sucessfully added!");
                    Clear();
                    flist.loadItems();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {

        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You sure you want to update this record? ", "update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    comm = new SqlCommand("UPDATE tblitems SET item_name = @item_name where id like'" + lblID.Text+ "'", conn);
                    comm.Parameters.AddWithValue("@item_name", txtName.Text);
                    //comm.Parameters.AddWithValue("@item_code", txtId.Text);
                    //comm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("brand has been updated");
                    flist.loadItems();
                    this.Dispose();
                }


            }
            catch (Exception ex)
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
