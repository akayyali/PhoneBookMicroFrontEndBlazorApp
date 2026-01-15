using Contacts.Domain.Entities;
using Contacts.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<ContactGroup> ContactGroups => Set<ContactGroup>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("contacts");
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactGroupConfiguration());
        }

    }
}
