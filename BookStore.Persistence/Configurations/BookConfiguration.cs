﻿using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnType("varchar").HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasPrecision(18, 2).IsRequired();

        builder.Property(x => x.ImageName)
            .HasColumnType("varchar(Max)")
            .IsRequired(false);

        builder.HasOne(x => x.Genre)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.GenreId)
            .IsRequired(false);

        builder.HasData(SeedDatabase.GetBooks());

        builder.ToTable("Books");
    }
}
