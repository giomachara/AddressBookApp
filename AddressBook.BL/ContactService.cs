using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AddressBook.DAL;
using AddressBook.Models;

namespace AddressBook.BL
{
    public sealed class ContactService
    {
        //ToDo: Should not contain duplicate ids.
        private IList<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>();
        }

        public string FilePath { get; private set; }
        public bool IsModified { get; private set; } = false;

        public Contact Get(int id)
        {
            if (!_contacts.Any(x => x.Id == id))
            {
                throw new ArgumentException($"Contact with the ID: {id} could not be found");
            }
            return _contacts.FirstOrDefault(contact => contact.Id == id);

            //foreach (Contact contact in _contacts)
            //{
            //    if (contact.Id == id)
            //    {
            //        return contact;
            //    }
            //}
            //return null;
        }

        public IEnumerable<Contact> Set(string searchCriteria)
        {
            foreach (Contact contact in _contacts)
            {
                if (contact.FirstName.Contains(searchCriteria) ||
                    contact.LastName.Contains(searchCriteria) ||
                    contact.Phone.Contains(searchCriteria) ||
                    contact.Email.Contains(searchCriteria))
                {
                    yield return contact;
                }
            }

            //List<Contact> result = new List<Contact>();
            //foreach (Contact contact in _contacts)
            //{
            //    if (contact.FirstName.Contains(searchCriteria) ||
            //        contact.LastName.Contains(searchCriteria) ||
            //        contact.Phone.Contains(searchCriteria) ||
            //        contact.Email.Contains(searchCriteria))
            //    {
            //        result.Add(contact);
            //    }
            //}

            //return result;
        }

        public void Add(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            if (_contacts.Any(x => x.Id == contact.Id))
            {
                throw new ArgumentException($"Contact with the same ID: {contact.Id} already exists.");
            }
            _contacts.Add(contact);
        }

        public void Edit(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            int index = _contacts.IndexOf(contact);
            _contacts[index] = contact;
        }

        public void Remove(int id)
        {
            _contacts.Remove(Get(id));
        }

        public void Load(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            _contacts = ContactRepository.Load(filePath).ToList();
            FilePath = filePath;
            IsModified = false;
        }

        public void Save(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            ContactRepository.Save(_contacts, filePath);
            FilePath = filePath;
            IsModified = false;
        }
    }
}
