using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Proj.Core.Domain;

namespace Proj.Infrastructure.Service
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task AddContactAsync(Contact contact);
        Task AddAddressAsync(Address address, int id);
        Task DeleteContactAsync(int id);
        Task DeleteAddressAsync(int id);
        Task UpdateContactAsync(Contact contact, int id);
        Task UpdateAddressAsync(Address address, int id);
        Task<Contact> GetContact(int id);
        Task<Address> GetAddress(int id);

    }
}