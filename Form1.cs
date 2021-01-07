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


namespace pos
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.productName.Text != "" && this.productPrice.Text != "")
            {
                productsList.Items.Add(this.productName.Text +" - $"+this.productPrice.Text);
                comboBox1.Items.Add(this.productName.Text);
                this.productName.Focus();
                this.productName.Clear();
                this.productPrice.Clear();

            }
            else
            {
                MessageBox.Show("Please enter both valus","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add(comboBox1.SelectedItem.ToString());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void productName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
