using AddressBook.BL;
using AddressBook.Models;
using System;
using System.Windows.Forms;

namespace AddressBook.App
{
    public partial class Form1 : Form
    {
        private ContactService contactService;

        public Form1()
        {
            InitializeComponent();
            contactService = new ContactService();


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(
                     Convert.ToInt32(textBox_id.Text), textBox_name.Text,
                     textBox_surname.Text, textBox_email.Text, textBox_phone.Text);


            try
            {
                contactService.Add(contact);
                MessageBox.Show("Contact added successfully!");
                listBox1.Items.Add(contact);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while adding the contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
