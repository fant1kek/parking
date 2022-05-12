using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form3 : Form
    {
        string place;
        public Form3(List<string> values)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            place = values[0];
            label1.Text = $"Место №{values[0]}";
            textBox1.Text = values[1];
            textBox2.Text = values[2];
            textBox3.Text = values[3];
            textBox4.Text = values[4];
            textBox5.Text = values[6];
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Вы действительно хотите внести изменение в место №{place}?", "Изменить место", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataBase DB = new DataBase();
                DB.DBUpdate(textBox1.Text, textBox2.Text, Convert.ToDouble(textBox4.Text), textBox3.Text, place, textBox5.Text);
                MessageBox.Show("Изменения были сохранены", "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Form2().Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
