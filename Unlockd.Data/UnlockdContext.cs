using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Unlockd.Data.Mapping.Auth;
using Unlockd.Data.Mapping.Blog;
using Unlockd.Data.Mapping.CMS;
using Unlockd.Data.Mapping.Device;
using Unlockd.Data.Mapping.Network;
using Unlockd.Data.Mapping.Pricings;
using Unlockd.Data.Mapping.Services;
using Unlockd.Data.Mapping.Testimonials;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Domain.Entities.CMS;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Domain.Entities.Services;
using Unlockd.Domain.Entities.Testimonials;

namespace Unlockd.Data
{
    public class UnlockdContext : IdentityDbContext<User>
    {
        public UnlockdContext(DbContextOptions<UnlockdContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Auth//
            //new UserTypeMap(builder.Entity<UserType>());

            //Blog//
            new BlogPostMap(builder.Entity<BlogPost>());
            new BlogCategoryMap(builder.Entity<BlogCategory>());

            //CMS//
            new MediaMap(builder.Entity<Media>());
            new PageContentMap(builder.Entity<PageContent>());
            new PageInfoMap(builder.Entity<PageInfo>());

            //Device//
            new BrandMap(builder.Entity<Brand>());
            new DeviceModelMap(builder.Entity<DeviceModel>());

            //Network//
            new CountryMap(builder.Entity<Country>());
            new NetworkCarrierMap(builder.Entity<NetworkCarrier>());

            //Services//
            new ContactMap(builder.Entity<Contact>());
            new FAQMap(builder.Entity<FAQ>());
            new OurInfoMap(builder.Entity<OurInfo>());
            new BrandFAQmap(builder.Entity<BrandFAQ>());
            new SupportMenuMap(builder.Entity<SupportMenu>());

            //Order//
            new OrderMap(builder.Entity<Order>());

            //Testimonials
            new TestimonialMap(builder.Entity<Testimonial>());

            //Pricing
            new CarrierCheckMap(builder.Entity<CarrierCheck>());
            new ICloudCheckMap(builder.Entity<ICloudCheck>());
            new BlackListCheckMap(builder.Entity<BlackListCheck>());
            new SprintStatusCheckMap(builder.Entity<SprintStatusCheck>());
            new ModelVsCarrierMap(builder.Entity<ModelVsCarrier>());
        }
    }
}
