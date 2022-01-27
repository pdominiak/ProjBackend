using System;
using Proj.Core.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Proj.Core.Domain;
using System.Collections.Generic;
using Proj.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Proj.Infrastructure.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private static ContactsDbContext _context; 
      
      
        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }
        public async Task AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }
        public async Task AddAddressAsync(Address address, int id)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateContactAsync(Contact contact, int id)
        {
            _context.Contacts.SingleOrDefault(x => x.ContactID == id).setNonIdData(contact);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
        public async Task UpdateAddressAsync(Address address, int id)
        {
            _context.Addresses.SingleOrDefault(x => x.AddressID == id).SetNonIdData(address);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
        public async Task DeleteContactAsync(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(x => x.ContactID == id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAddressAsync(int id)
        {
            var address = _context.Addresses.SingleOrDefault(x => x.AddressID == id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            var contacts = _context.Contacts
                .Include(x=>x.Addresses)
                .ToList();
            return await Task.FromResult(contacts);
        }
        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            var addresses = _context.Addresses.ToList();
            await _context.SaveChangesAsync();
            return await Task.FromResult(addresses);
        }
        public async Task<Address> GetAddress(int id)
        {
            var address = _context.Addresses.Where(x => x.AddressID == id).SingleOrDefault();
            return await Task.FromResult(address);
        }
        public async Task<Contact> GetContact(int id)
        {
            var contact = _context.Contacts.Include(x => x.Addresses).Where(x => x.ContactID == id).SingleOrDefault();
            return await Task.FromResult(contact);
        }



    }
}