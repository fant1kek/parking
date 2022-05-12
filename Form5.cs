using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form5 : Form
    {
        DataBase DB = new DataBase();
        public Form5()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            for (int i = 0; i < DB.GetAdministrators().Count; i++)
            {
                comboBox1.Items.Add(DB.GetAdministrators()[i]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"Логин: (\w+), Пароль: (\w+)");
            string login = regex.Match(comboBox1.SelectedItem.ToString()).Groups[1].Value, password = regex.Match(comboBox1.SelectedItem.ToString()).Groups[2].Value;
            DB.DeleteAdministrator(login, password);
            comboBox1.Items.Clear();
            for (int i = 0; i < DB.GetAdministrators().Count; i++)
            {
                comboBox1.Items.Add(DB.GetAdministrators()[i]);
            }
            comboBox1.SelectedIndex = 0;
            MessageBox.Show("Администратор был удален", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
