using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj.Core.Domain;
namespace Proj.Infrastructure.DataAccess
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()              
                .HasOne(p => p.Contact)
                .WithMany(b => b.Addresses)
                .HasForeignKey(p => p.ContactID);

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
