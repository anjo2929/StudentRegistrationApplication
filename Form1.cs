using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentRegistrationApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            programtoapply.Items.Add("BS in Information Technology");
            programtoapply.Items.Add("BS in Computer Science");
            programtoapply.Items.Add("BS in Business Administration");
            programtoapply.Items.Add("BS in Accountancy");
            programtoapply.Items.Add("BS in Hospitality Management");
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstname.Text) ||
                string.IsNullOrEmpty(lastname.Text) ||
                programtoapply.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error");
                return;
            }

            string firstName = firstname.Text;
            string middleName = middlename.Text;
            string lastName = lastname.Text;
            string gender = male.Checked ? "Male" : "Female";
            DateTime dob = dateTimePicker.Value;
            string program = programtoapply.SelectedItem.ToString();

            DisplayStudentInfo(firstName, lastName); 
            DisplayStudentInfo(firstName, middleName, lastName, gender); 
            DisplayStudentInfo(firstName, middleName, lastName, gender, dob, program);

           
            ClearForm();
        }

        private void ClearForm()
        {
            firstname.Text = "";
            middlename.Text = "";
            lastname.Text = "";
            male.Checked = false;
            female.Checked = false;
            dateTimePicker.Value = DateTime.Now;
            programtoapply.SelectedIndex = -1; 
            pictureBox.Image = null; 
        }

        public void DisplayStudentInfo(string firstName, string lastName)
        {
            MessageBox.Show($"Student name: {firstName} {lastName}");
        }

        public void DisplayStudentInfo(string firstName, string middleName, string lastName, string gender)
        {
            MessageBox.Show($"Student name: {firstName} {middleName} {lastName}\nGender: {gender}");
        }
  
        public void DisplayStudentInfo(string firstName, string middleName, string lastName, string gender, DateTime dob, string program)
        {
            MessageBox.Show($"Student name: {firstName} {middleName} {lastName}\nGender: {gender}\nDate of birth: {dob.ToShortDateString()}\nProgram: {program}");
        }
    }
}
