using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_too
{
    public partial class savereport : Form
    {
        public savereport()
        {
            InitializeComponent();
        }

        private void exit_label_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void set_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings settings = new settings();
            settings.Show();
        }

        private void tape_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            tape tape = new tape();
            tape.Show();
        }

        private void lk_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            lk lk = new lk();
            lk.Show();
        }

        private void reg_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            singup singup = new singup();
            singup.Show();
        }

        private void auth_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            auth auth = new auth();
            auth.Show();
        }

        private void main_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            main main = new main();
            main.Show();
        }
    }
}
