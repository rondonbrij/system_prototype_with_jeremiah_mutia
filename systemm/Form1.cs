using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace systemm
{
    public partial class Form1 : Form
    {
        private const string AttendanceFilePath = "attendance.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(AttendanceFilePath))
            {
                string[] lines = File.ReadAllLines(AttendanceFilePath);
                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = name_txtbox.Text.Trim();
            string lastName = lastname_txtbox.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please enter your full name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string attendanceRecord = $"{DateTime.Now}: {lastName}, {firstName}";
            listBox1.Items.Add(attendanceRecord);
            File.AppendAllText(AttendanceFilePath, attendanceRecord + Environment.NewLine);

            name_txtbox.Clear();
            lastname_txtbox.Clear();
        }





        private void delete_selected_btn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Error, nothing selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedRecord = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(selectedRecord);

            // Delete the selected record from the file
            string[] lines = File.ReadAllLines(AttendanceFilePath);
            File.WriteAllLines(AttendanceFilePath, lines.Where(line => line != selectedRecord));
        }



        private void clear_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void lastname_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}