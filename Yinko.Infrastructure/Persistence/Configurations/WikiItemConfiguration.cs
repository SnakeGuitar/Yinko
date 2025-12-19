using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Entities;

namespace Yinko.Infrastructure.Persistence.Configurations
{
    public class WikiItemConfiguration : IEntityTypeConfiguration<WikiItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WikiItem> builder)
        {
            builder.Property(w => w.Term)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(w => w.Term);

            builder.HasOne(w => w.Book)
                   .WithMany(b => b.Wiki)
                   .HasForeignKey(w => w.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
