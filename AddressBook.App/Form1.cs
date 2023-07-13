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
                listBox1.Items.Add(contact);
                MessageBox.Show("Contact added successfully!");                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            Contact selectedContact = listBox1.SelectedItem as Contact;

            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                MessageBox.Show($"ID should not be empty");
                return;
            }

            try
            {
                if (contactService.Get(Convert.ToInt32(textBox_id.Text)) != null)
                {
                    contactService.Remove(Convert.ToInt32(textBox_id.Text));
                    ListBoxRemoveId(textBox_id.Text);
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show($"An error occurred while removing the contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (selectedContact !=null)
            {
                contactService.Remove(selectedContact.Id);
                listBox1.Items.Remove(selectedContact);
                MessageBox.Show("Contact removed successfully!");
            }
        }

        private void ListBoxRemoveId(string id)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Contact contact = listBox1.Items[i] as Contact;
                if (contact != null && contact.Id.ToString() == id)
                {
                    listBox1.Items.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
