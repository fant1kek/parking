using System;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox2.UseSystemPasswordChar = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            if (DB.AddAdministrator(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show($"Вы успешно добавили администратора", "Добавить администратора", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show($"Данный логин уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Form5().Show();
        }
    }
}
