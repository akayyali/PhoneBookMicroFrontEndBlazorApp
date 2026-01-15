using Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Infrastructure.Configurations
{
    public class ContactGroupConfiguration : IEntityTypeConfiguration<ContactGroup>
    {
        public void Configure(EntityTypeBuilder<ContactGroup> builder)
        {
            builder.ToTable("ContactGroups");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
            builder.Property(g => g.Description).HasMaxLength(500);
            builder.HasIndex(g => g.Name).IsUnique();
        }
    }
}
