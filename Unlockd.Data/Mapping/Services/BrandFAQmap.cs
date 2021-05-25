using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Data.Mapping.Services
{
    public class BrandFAQmap
    {
        public BrandFAQmap(EntityTypeBuilder<BrandFAQ> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Question);
            builder.Property(t => t.Answer);
            builder.Property(t => t.SupportMenuId);
            builder.Property(t => t.BrandId);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);
            builder.HasOne(s => s.SupportMenu)
                .WithMany(s => s.BrandFAQ)
                .HasForeignKey(t => t.SupportMenuId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
            builder.HasOne(s => s.Brand)
                .WithMany(s => s.BrandFAQ)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
