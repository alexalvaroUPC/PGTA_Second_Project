﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTA_Second_Project
{
    public partial class NuevaZonaRegistro : Form
    {
        private double d1 = -1;
        private double d2 = -1;
        public NuevaZonaRegistro()
        {
            InitializeComponent();
        }
        public double getLength() { return d1; }
        public double getWidth() { return d2; }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.d1 = Convert.ToDouble(textBox1.Text);
                this.d2 = Convert.ToDouble(textBox2.Text);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Porfavor introduzca datos númericos");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
