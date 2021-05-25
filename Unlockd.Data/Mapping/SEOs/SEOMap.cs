using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unlockd.Domain.Entities.SEOEntities;

namespace Unlockd.Data.Mapping.SEOs
{
   public class SEOMap
    {
        public SEOMap(EntityTypeBuilder<SEO> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title);
            builder.Property(t => t.Description);
            builder.Property(t => t.Slug);
        }
    }
}
