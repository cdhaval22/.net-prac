using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BindingSourcenavigator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db1DataSet.tb1' table. You can move, or remove it, as needed.
            this.tb1TableAdapter.Fill(this.db1DataSet.tb1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String c = "datasource=localhost;port=3306;username=root;password=";
            String q = "insert into db1.tb1 (`Name`,`En.No`,`Contact`,`Department`,`E-Mail`,`Sem`) values('"+this.textBox1.Text+ "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "');";
            MySqlConnection con = new MySqlConnection(c);
            MySqlCommand com = new MySqlCommand(q,con);
            MySqlDataReader mr;
            try
            {
                con.Open();
                mr = com.ExecuteReader();
                MessageBox.Show("Submitted");
                while (mr.Read())
                {

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
