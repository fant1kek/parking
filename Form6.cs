using System;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            if (DB.Authorization(textBox1.Text, textBox2.Text))
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
