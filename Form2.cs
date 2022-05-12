using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Parking
{
    public partial class Form2 : Form
    {
        DataBase DB = new DataBase();
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DB.CheckPlaces();
            for (int i = 0; i < DB.GetOccupiedPlaces().Count; i++)
            {
                comboBox1.Items.Add(DB.GetOccupiedPlaces()[i]);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                Regex regex = new Regex(@"\d+");
                var result = MessageBox.Show($"Вы действительно хотите освободить место № {regex.Match(comboBox1.SelectedItem.ToString())}?", "Освободить место", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DB.DBUpdate("", "", 0, "", regex.Match(comboBox1.SelectedItem.ToString()).Value, "");
                    MessageBox.Show($"Вы успешно освободили место {regex.Match(comboBox1.SelectedItem.ToString())}.", $"Место {regex.Match(comboBox1.SelectedItem.ToString())}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Items.Clear();
                    for (int i = 0; i < DB.GetOccupiedPlaces().Count; i++)
                    {
                        comboBox1.Items.Add(DB.GetOccupiedPlaces()[i]);
                    }
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Место не выбрано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                Regex regex = new Regex(@"\[(\d+)\] - (\w+) \| (\w+)\((\w+)\) - время аренды\\начало аренды\\конец аренды: (\d+)\\(\d+.\d+.\d+\s\d+:\d+:\d+)\\(\d+.\d+.\d+ \d+:\d+:\d+)");
                List<string> values = new List<string>();
                for (int i = 1; regex.Match(comboBox1.SelectedItem.ToString()).Groups.Count > i; i++)
                {
                    values.Add(regex.Match(comboBox1.SelectedItem.ToString()).Groups[i].Value);
                }
                new Form3(values).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Место не выбрано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Добавить место на парковку?", "Добавить место", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DB.AddPlace();
                MessageBox.Show($"Вы успешно добавили место", "Добавить место", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
