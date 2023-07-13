using System;
using System.Collections.Generic;
using System.IO;
using AddressBook.Models;

namespace AddressBook.DAL
{
    public static class ContactRepository
    {
        public static IEnumerable<Contact> Load(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            var reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
            var contacts = new List<Contact>();

            try
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Contact contact = new Contact(
                        reader.ReadInt32(),
                        reader.ReadString(),
                        reader.ReadString(),
                        reader.ReadString(),
                        reader.ReadString()
                    );
                    contacts.Add(contact);
                }

                ValidateList(contacts);

                return contacts;
            }
            finally
            {
                reader.Close();
            }
        }

        public static void Save(IEnumerable<Contact> contacts, string filePath)
        {
            if (contacts == null) throw new ArgumentNullException(nameof(contacts));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            ValidateList(contacts);
            var writer = new BinaryWriter(new FileStream(filePath, FileMode.Create));

            try
            {
                foreach (var contact in contacts)
                {
                    writer.Write(contact.Id);
                    writer.Write(contact.FirstName);
                    writer.Write(contact.LastName);
                    writer.Write(contact.Email);
                    writer.Write(contact.Phone);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        private static void ValidateList(IEnumerable<Contact> contacts)
        {
            var hashset = new HashSet<int>();

            foreach (var contact in contacts)
            {
                if (!hashset.Add(contact.Id))
                {
                    throw new Exception($"Id {contact.Id} is duplicated");
                }
            }
        }
    }
}
