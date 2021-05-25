using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Data.Mapping.Auth
{
    public class UserTypeMap
    {
       public UserTypeMap(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UserTypeName);
        }
    }
}
