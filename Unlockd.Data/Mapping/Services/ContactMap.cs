using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Data.Mapping.Services
{
   public class ContactMap
    {
        public ContactMap(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FirstName);
            builder.Property(t => t.LastName);
            builder.Property(t => t.Email);
            builder.Property(t => t.CountryId);
            builder.Property(t => t.Subject);
            builder.Property(t => t.Description);
        }
    }
}
