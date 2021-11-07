using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactsApp.Entity;

namespace ContactsApp.Abstract
{
    public interface IContactsRepository
    {
        Task<ObservableCollection<Contact>> GetContactsAsync(
            string firstName, string lastName);
        Task<bool> AddContactAsync(Contact contactToAdd);
        Task<bool> UpdateContactAsync(Contact contactToUpdate);
        Task<bool> DeleteContactAsync(Contact contactToDelete);
    }
}
