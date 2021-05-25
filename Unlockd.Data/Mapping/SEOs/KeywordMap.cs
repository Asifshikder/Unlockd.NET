using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unlockd.Domain.Entities.SEOEntities;

namespace Unlockd.Data.Mapping.SEOs
{
   public class KeywordMap
    {
        public KeywordMap(EntityTypeBuilder<Keyword> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.HasOne(s => s.SEO)
                .WithMany(s => s.Keywords)
                .HasForeignKey(t => t.SEOId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
