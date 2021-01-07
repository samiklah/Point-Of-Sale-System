using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
//using System.Data.SqlClient;


namespace pos
{
    public partial class POS : Form
    {
                                         //write your provider here
        OleDbConnection cn = new OleDbConnection(@"");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand cmd;

        private int SelectedID;

        public POS()
        {
            InitializeComponent();
            FillDatagridView();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From products", cn);
            Da.Fill(Dt);
            productsList.DataSource = Dt;
            comboBox1.DataSource = Dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.productName.Text != "" && this.productPrice.Text != "")
            {
                //productsList.Items.Add(this.productName.Text +" - $"+this.productPrice.Text);
                //comboBox1.Items.Add(this.productName.Text);
                cmd = new OleDbCommand("Insert Into products Values ('"+this.productName.Text+"',"+Convert.ToInt32(this.productPrice.Text),cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                FillDatagridView();

                MessageBox.Show("Added Sucessfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productsList_DoubleClick(object sender, EventArgs e)
        {
            SelectedID = this.productsList.CurrentRow.Cells[1].Value;
            productName.Text = this.productsList.CurrentRow.Cells[1].Value.ToString();
            productPrice.Text = this.productsList.CurrentRow.Cells[2].Value.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Update products Set Name ='"+productName.Text+"', Price="+Convert.ToInt32(productPrice.Text)+"where ID = "+SelectedID, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            MessageBox.Show("Updated Sucessfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Delete From products Where ID=" + SelectedID, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            MessageBox.Show("Deleted Sucessfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
