using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Entities;
using Yinko.Domain.Enums;

namespace Yinko.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                   .HasMaxLength(200)
                   .IsRequired()
                   .IsUnicode(true);

            builder.Property(b => b.Synopsis)
                .HasMaxLength(2000);

            builder.Property(b => b.Status)
                .HasConversion<int>();

            builder.HasOne(b => b.Author)
                   .WithMany(u => u.Books)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
