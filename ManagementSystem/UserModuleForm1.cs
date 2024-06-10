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

namespace ManagementSystem
{
    public partial class UserModuleForm1 : Form
    {

        SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\User\Documents\Msystem.mdf;Integrated Security = True; Connect Timeout = 30);
");
        SqlCommand cm = new SqlCommand();
        public UserModuleForm1()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(textPass.Text != textRepass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbUser(username,fullname,password,phone)VALUES(@username,@fullname,@password,@phone)", con);
                    cm.Parameters.AddWithValue("@username", textUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", textFullName.Text);
                    cm.Parameters.AddWithValue("@password", textPass.Text);
                    cm.Parameters.AddWithValue("@phone", textPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been saved Successfully");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            textUserName.Clear();
            textFullName.Clear();
            textPass.Clear();
            textRepass.Clear();
            textPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textPass.Text != textRepass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "Updating record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbUser SET fullname = @fullname, password = @password, phone =@phone WHERE username LIKE '" + textUserName.Text + "'  ", con);
                    cm.Parameters.AddWithValue("@fullname", textFullName.Text);
                    cm.Parameters.AddWithValue("@password", textPass.Text);
                    cm.Parameters.AddWithValue("@phone", textPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been Successfully Updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void UserModuleForm1_Load(object sender, EventArgs e)
        {

        }
    }
}

