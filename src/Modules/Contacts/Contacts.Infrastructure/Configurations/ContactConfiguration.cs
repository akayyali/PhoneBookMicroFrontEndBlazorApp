using Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Company).HasMaxLength(200);
            builder.Property(c => c.JobTitle).HasMaxLength(100);
            builder.Property(c => c.Notes).HasMaxLength(1000);
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.IsFavorite).IsRequired();

            builder.OwnsOne(c => c.PhoneNumber, phone =>
            {
                phone.Property(p => p.Number).IsRequired().HasMaxLength(20).HasColumnName("PhoneNumber");
                phone.Property(p => p.CountryCode).HasMaxLength(5).HasColumnName("CountryCode");
                phone.Property(p => p.Extension).HasMaxLength(10).HasColumnName("PhoneExtension");
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Address).HasMaxLength(256).HasColumnName("Email");
                email.HasIndex(e => e.Address);
            });

            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(a => a.Street).HasMaxLength(200).HasColumnName("Street");
                address.Property(a => a.Suburb).HasMaxLength(100).HasColumnName("City");
                address.Property(a => a.State).HasMaxLength(100).HasColumnName("State");
                address.Property(a => a.PostCode).HasMaxLength(20).HasColumnName("PostalCode");
                address.Property(a => a.Country).HasMaxLength(100).HasColumnName("Country");
            });

            builder.HasOne(c => c.ContactGroup)
                .WithMany(g => g.Contacts)
                .HasForeignKey(c => c.ContactGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(c => c.FirstName);
            builder.HasIndex(c => c.LastName);
            builder.HasIndex(c => c.IsFavorite);
        }
    }
}
