using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();
        }

        //step to show sub form in main form
        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ChildForm);
            panelMain.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForms());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
        }

        private void btnCategories_Click_1(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }
    }
}
