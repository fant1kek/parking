using System;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form1 : Form
    {
        DataBase DB = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DB.CheckPlaces();
            for (int i = 0; i < DB.GetFreePlaces().Count; i++)
            {
                comboBox2.Items.Add(DB.GetFreePlaces()[i]);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Не все заполнено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetPlaces SP = new SetPlaces(comboBox2.Text);
                if (comboBox1.SelectedIndex == 0)
                {
                    PassengerPlace passengerPlace = new PassengerPlace(int.Parse(textBox3.Text));
                    var result = MessageBox.Show($"Вы собираетесь арендовать место №{SP.place} на {passengerPlace.RentalTime} часов\nСтоимость аренды будет {passengerPlace.GetPrice()} р.\nВсе верно?", "Аренда", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DB.SetPlace(new PassengerCar(textBox1.Text, textBox2.Text), new PassengerPlace(int.Parse(textBox3.Text)), new SetPlaces(comboBox2.Text));
                        MessageBox.Show("Вы успешно арендовали место.", $"Место №{textBox3.Text}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBox1.SelectedIndex = -1;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox2.Items.RemoveAt(comboBox2.SelectedIndex);
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    TruckPlace truckPlace = new TruckPlace(int.Parse(textBox3.Text));
                    var result = MessageBox.Show($"Вы собираетесь арендовать место №{SP.place} на {truckPlace.RentalTime} часов\nСтоимость аренды будет {truckPlace.GetPrice()} р.\nВсе верно?", "Аренда", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DB.SetPlace(new TruckCar(textBox1.Text, textBox2.Text), new TruckPlace(int.Parse(textBox3.Text)), new SetPlaces(comboBox2.Text));
                        MessageBox.Show("Вы успешно арендовали место.", $"Место №{textBox3.Text}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBox1.SelectedIndex = -1;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox2.Items.RemoveAt(comboBox2.SelectedIndex);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
