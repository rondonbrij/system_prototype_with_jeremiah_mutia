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
            string name = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string attendanceRecord = $"{DateTime.Now}: {name}";
            listBox1.Items.Add(attendanceRecord);
            File.AppendAllText(AttendanceFilePath, attendanceRecord + Environment.NewLine);


            textBox1.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}