﻿using System;
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
    public partial class CustomerButton : PictureBox
    {
        public CustomerButton()
        {
            InitializeComponent();
        }

        private Image Normalimage;
        private Image Hoverimage;

        public Image ImageNormal
        {
            get { return Normalimage; } 
            set { Normalimage = value; }
        }

        public Image HoverImage
        {
            get { return Hoverimage; }
            set { Hoverimage = value; }
        }

        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            this.Image = Hoverimage;
        }

        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = Normalimage;
        }
    }
}
