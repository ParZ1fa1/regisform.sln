using MySql.Data.MySqlClient;
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

namespace project_too
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            singup singup = new singup();
            singup.Show();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void in_btn_Click(object sender, EventArgs e)
        {

            string logusers = textBox3.Text;
            string pasusers = textBox2.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL  AND `password` =  @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = logusers;  
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = pasusers;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                this.Hide();
                main main = new main();
                main.Show();
            }
                
            
        }

    
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void auth_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }
    }
}
