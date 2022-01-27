using System;
using Proj.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Proj.Core.Repositories
{
    public interface IContactsRepository
    {
   
        Task AddContactAsync(Contact contact);
        Task AddAddressAsync(Address address, int id);
         Task UpdateContactAsync(Contact contact, int id);
        Task UpdateAddressAsync(Address address,int id);
         Task DeleteContactAsync(int id);
        Task DeleteAddressAsync(int id);
         Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> GetAddress(int id);
        Task<Contact> GetContact(int id);
    }
}