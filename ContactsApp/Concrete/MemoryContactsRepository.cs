using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ContactsApp.Abstract;
using ContactsApp.Entity;

namespace ContactsApp.Concrete
{
    public class MemoryContactsRepository : IContactsRepository
    {
        private ObservableCollection<Contact> contacts;

        public MemoryContactsRepository()
        {
            contacts = new ObservableCollection<Contact>()
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "Ahmad",
                    LastName = "Saeed",
                    Tel = "123456",
                    Email = "admin@example.com",
                    Hobbies = "Swimming"
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Mahmood",
                    LastName = "Maktabi",
                    Tel = "852136",
                    Email = "info@example.com",
                    Hobbies = "Reading"
                },
                new Contact()
                {
                    Id = 3,
                    FirstName = "Mazen",
                    LastName = "Najem",
                    Tel = "987456",
                    Email = "it@example.com",
                    Hobbies = "Swimming"
                },
                new Contact()
                {
                    Id = 4,
                    FirstName = "Sawsan",
                    LastName = "Hilal",
                    Tel = "741258",
                    Email = "sales@example.com",
                    Hobbies = "Writing, Reading"
                },
                new Contact()
                {
                    Id = 5,
                    FirstName = "Musab",
                    LastName = "Aga",
                    Tel = "357159",
                    Email = "admin@example.com",
                    Hobbies = "Sport"
                },

            };
        }

        public async Task<bool> AddContactAsync(Contact contactToAdd)
        {
            return await Task.Factory.StartNew(() =>
            {
                contactToAdd.Id = contacts.Count() + 1;
                contacts.Add(contactToAdd);
                return true;
            });
        }

        public async Task<bool> DeleteContactAsync(Contact contactToDelete)
        {
            return await Task.Factory.StartNew(() =>
            {
                var result = (from contact in contacts
                                  where contact.Id != contactToDelete.Id
                                  select contact);
                if (result != null)
                {
                    contacts = new ObservableCollection<Contact>(result);
                    contactToDelete = null;
                }
                return result != null;
            });

        }

        public async Task<ObservableCollection<Contact>> GetContactsAsync(string firstName, string lastName)
        {
            return await Task.Factory.StartNew(() =>
            {
                IEnumerable<Contact> result = from contact in contacts
                                              where
contact.FirstName.ToUpper().Contains(firstName.ToUpper()) &&
contact.LastName.ToUpper().Contains(lastName.ToUpper())
                                              select contact;
                ObservableCollection<Contact> tmp =
                new ObservableCollection<Contact>(result);

                return tmp;
            });
            
        }

        public async Task<bool> UpdateContactAsync(Contact contactToUpdate)
        {
            return await Task.Factory.StartNew(() =>
            {
                Contact result = (from contact in contacts
                                  where contact.Id == contactToUpdate.Id
                                  select contact).FirstOrDefault();
                if (result != null)
                {
                    contactToUpdate.FirstName = result.FirstName;
                    contactToUpdate.LastName = result.LastName;
                    contactToUpdate.Email = result.Email;
                    contactToUpdate.Tel = result.Tel;
                    contactToUpdate.Hobbies = result.Hobbies;
                }
                return result != null;
            });
        }
    }
}
