using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_too
{


    public partial class singup : Form
    {
        public singup()
        {
            InitializeComponent();
        }
        
        private void auth_btn_Click(object sender, EventArgs e)
        {
           
                this.Hide();
                auth auth = new auth();
                auth.Show();
            
        }

        private void close_lb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Введите имя", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show( "Введите фамилию", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show( "Введите отчество","Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }                                       
            if (textBox3.Text == "")
            {
                MessageBox.Show( "Введите электронную почту","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите пароль","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите повторно пароль","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

       
           

            if (chekUser())
                return;

           

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `Name`, `Surname`, `Second name`, `return password`)  VALUES (@login, @password, @name, @surname, @secondanme, @returnpassword)", db.GetConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@secondanme", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@returnpassword", MySqlDbType.VarChar).Value = textBox1.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                auth auth = new auth();
                auth.Show();
            }
            

            db.closeConnection();
        }


        public Boolean chekUser()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox3.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show( "Такой пользователь уже существует" ,"Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Question);
                return true;
            }
            else
                return false;
        }
 
    }
}
