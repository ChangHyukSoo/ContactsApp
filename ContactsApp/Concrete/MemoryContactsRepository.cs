using System;
using System.Collections.ObjectModel;
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

        public Task<bool> AddContactAsync(Contact contactToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContactAsync(Contact contactToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Contact>> GetContactsAsync(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContactAsync(Contact contactToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
