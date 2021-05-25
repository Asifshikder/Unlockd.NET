using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Domain.Entities.SalesAndOrder;

namespace Unlockd.Data.Mapping.Blog
{
   public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.AddressLine);
            builder.Property(t => t.CityOrTown);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);
            builder.Property(t => t.DeviceModelId);
            builder.Property(t => t.Email);
            builder.Property(t => t.Forename);
            builder.Property(t => t.IMEI);
            builder.Property(t => t.NetworkCarrierId);
            builder.Property(t => t.OrderStatus);
            builder.Property(t => t.Surname);
            builder.Property(t => t.TotalPrice);
            builder.Property(t => t.UnlockType);
            builder.Property(t => t.ZipOrPostcode);
        }
    }
}
