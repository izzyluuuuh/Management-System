using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManagementSystem
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }
        int startPoint = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startPoint += 2;
            progressBar1.Value = startPoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                LoginForm login = new LoginForm();
                this.Close(); 
                login.ShowDialog();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
