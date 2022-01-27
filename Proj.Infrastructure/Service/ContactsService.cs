using System;
using System.Threading.Tasks;
using Proj.Core.Domain;
using Proj.Infrastructure.Repositories;
using Proj.Core.Repositories;
using System.Collections.Generic;
using System.Xml;

namespace Proj.Infrastructure.Service
{
    public class ContactsService: IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository repository)
        {
            _contactsRepository = repository;
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            
            return await _contactsRepository.GetAllContactsAsync();
        }
        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _contactsRepository.GetAllAddressesAsync();
        }
        public async Task AddContactAsync(Contact contact)
        {
             await _contactsRepository.AddContactAsync(contact);    

        }

        public async Task AddAddressAsync(Address address, int id)
        {
            await _contactsRepository.AddAddressAsync(address ,id);
        }
        public async Task DeleteContactAsync(int id)
        {
            await _contactsRepository.DeleteContactAsync(id);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _contactsRepository.DeleteAddressAsync(id);
        }

        public async Task UpdateContactAsync(Contact contact, int id)
        {
            await _contactsRepository.UpdateContactAsync(contact, id);
        }

        public async Task UpdateAddressAsync(Address address, int id)
        {
            await _contactsRepository.UpdateAddressAsync(address, id);
        }
        public async Task<Contact> GetContact(int id)
        {
            return await _contactsRepository.GetContact(id);
        }
        public async Task<Address> GetAddress(int id)
        {
            return await _contactsRepository.GetAddress(id);
        }
    }
}