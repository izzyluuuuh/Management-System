using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManagementSystem
{
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\dbIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboCat.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to save this product?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbProduct (pname,pqty,pprice,pdescription,pcategory)VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", textPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(textPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(textPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", textPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been saved Successfully");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            textPname.Clear();
            textPQty.Clear();
            textPPrice.Clear();
            textPDes.Clear();
            comboCat.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                {
                    cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty = @pqty, pdescription = @pdescription, pprice =@pprice, pcategory = @pcategory WHERE pid LIKE '" + lblPid.Text + "'  ", con);
                    cm.Parameters.AddWithValue("@pname", textPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(textPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(textPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", textPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been Successfully Updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
