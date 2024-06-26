﻿using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations;

public sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.AuthorName)
            .HasColumnType("varchar")
            .HasMaxLength(100).IsRequired();

        builder.HasMany(x => x.Books)
            .WithMany(x => x.Authors)
            .UsingEntity<AuthorBooks>();

        builder.HasData(SeedDatabase.GetAuthors());

        builder.ToTable("Authors");
    }
}
