using AddressBook.DAL;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AddressBook.BL;

namespace AddressBook.Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ContactService contactService = new ContactService();

			Contact contact1 = new Contact(1, "Gigi", "Patsatsia", "patsatsiagigi@gmail.com", "599999999");
			Contact contact2 = new Contact(2, "Nika", "Nodia", "nodianika@gmail.com", "599999998");
			Contact contact3 = new Contact(3, "Elene", "Nodia", "nodiaelene@gmail.com", "599999997");
			Contact contact4 = new Contact(4, "Elene", "Test", "nodiaelene@gmail.com", "599999997");

			contactService.Add(contact1);
			contactService.Add(contact2);
			contactService.Add(contact3);
			contactService.Add(contact4);

			contact4 = new Contact(5, "Test", "Test", "nodiaelene@gmail.com", "599999997");
			contactService.Edit(contact4);

			//contactService.Remove(contact4.Id);

			////ToDo: Test ContactRepository functionality here...
			//var contacts = new List<Contact>();

			//Contact contact1 = new Contact(1, "Gigi", "Patsatsia", "patsatsiagigi@gmail.com", "599999999");
			//Contact contact2 = new Contact(2, "Nika", "Nodia", "nodianika@gmail.com", "599999998");
			//Contact contact3 = new Contact(3, "Elene", "Nodia", "nodiaelene@gmail.com", "599999997");
			//contacts.Add(contact1);
			//contacts.Add(contact2);
			//contacts.Add(contact3);



			//ContactRepository.Save(contacts, @"D:\Conacts List.txt");
			//ContactRepository.Load(@"C:\Users\user\Desktop\Conacts List.txt");
		}
	}
}
