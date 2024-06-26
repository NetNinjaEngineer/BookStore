﻿// <auto-generated />
using BookStore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240503085717_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "George Orwell"
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "Harper Lee"
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "F. Scott Fitzgerald"
                        },
                        new
                        {
                            Id = 4,
                            AuthorName = "Jane Austen"
                        },
                        new
                        {
                            Id = 5,
                            AuthorName = "J. D. Salinger"
                        },
                        new
                        {
                            Id = 6,
                            AuthorName = "J. K. Rowling"
                        },
                        new
                        {
                            Id = 7,
                            AuthorName = "J. R. R. Tolkien"
                        },
                        new
                        {
                            Id = 8,
                            AuthorName = "J. R. R. Tolkien"
                        },
                        new
                        {
                            Id = 9,
                            AuthorName = "George Orwell"
                        },
                        new
                        {
                            Id = 10,
                            AuthorName = "C. S. Lewis"
                        },
                        new
                        {
                            Id = 11,
                            AuthorName = "Dan Brown"
                        },
                        new
                        {
                            Id = 12,
                            AuthorName = "Paulo Coelho"
                        },
                        new
                        {
                            Id = 13,
                            AuthorName = "Stieg Larsson"
                        },
                        new
                        {
                            Id = 14,
                            AuthorName = "Gillian Flynn"
                        },
                        new
                        {
                            Id = 15,
                            AuthorName = "Suzanne Collins"
                        },
                        new
                        {
                            Id = 16,
                            AuthorName = "Douglas Adams"
                        },
                        new
                        {
                            Id = 17,
                            AuthorName = "Charlotte Brontë"
                        },
                        new
                        {
                            Id = 18,
                            AuthorName = "Aldous Huxley"
                        },
                        new
                        {
                            Id = 19,
                            AuthorName = "Herman Melville"
                        },
                        new
                        {
                            Id = 20,
                            AuthorName = "George R. R. Martin"
                        },
                        new
                        {
                            Id = 21,
                            AuthorName = "Cormac McCarthy"
                        },
                        new
                        {
                            Id = 22,
                            AuthorName = "Khaled Hosseini"
                        },
                        new
                        {
                            Id = 23,
                            AuthorName = "Emily Brontë"
                        },
                        new
                        {
                            Id = 24,
                            AuthorName = "Fyodor Dostoyevsky"
                        },
                        new
                        {
                            Id = 25,
                            AuthorName = "Oscar Wilde"
                        },
                        new
                        {
                            Id = 26,
                            AuthorName = "Mary Shelley"
                        },
                        new
                        {
                            Id = 27,
                            AuthorName = "Alexandre Dumas"
                        },
                        new
                        {
                            Id = 28,
                            AuthorName = "Sylvia Plath"
                        },
                        new
                        {
                            Id = 29,
                            AuthorName = "Stephen King"
                        },
                        new
                        {
                            Id = 30,
                            AuthorName = "William Golding"
                        });
                });

            modelBuilder.Entity("BookStore.Domain.AuthorBooks", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorBooks", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 4
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 5
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 6
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 7
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 8
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 9
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 10
                        },
                        new
                        {
                            BookId = 11,
                            AuthorId = 11
                        },
                        new
                        {
                            BookId = 12,
                            AuthorId = 12
                        },
                        new
                        {
                            BookId = 13,
                            AuthorId = 13
                        },
                        new
                        {
                            BookId = 14,
                            AuthorId = 14
                        },
                        new
                        {
                            BookId = 15,
                            AuthorId = 15
                        },
                        new
                        {
                            BookId = 16,
                            AuthorId = 16
                        },
                        new
                        {
                            BookId = 17,
                            AuthorId = 17
                        },
                        new
                        {
                            BookId = 18,
                            AuthorId = 18
                        },
                        new
                        {
                            BookId = 19,
                            AuthorId = 19
                        },
                        new
                        {
                            BookId = 20,
                            AuthorId = 20
                        },
                        new
                        {
                            BookId = 21,
                            AuthorId = 21
                        },
                        new
                        {
                            BookId = 22,
                            AuthorId = 22
                        },
                        new
                        {
                            BookId = 23,
                            AuthorId = 23
                        },
                        new
                        {
                            BookId = 24,
                            AuthorId = 24
                        },
                        new
                        {
                            BookId = 25,
                            AuthorId = 25
                        },
                        new
                        {
                            BookId = 26,
                            AuthorId = 26
                        },
                        new
                        {
                            BookId = 27,
                            AuthorId = 27
                        },
                        new
                        {
                            BookId = 28,
                            AuthorId = 28
                        },
                        new
                        {
                            BookId = 29,
                            AuthorId = 29
                        },
                        new
                        {
                            BookId = 30,
                            AuthorId = 30
                        });
                });

            modelBuilder.Entity("BookStore.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("varchar(Max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 24,
                            Price = 10.99m,
                            PublicationYear = 1949,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 7,
                            Price = 12.99m,
                            PublicationYear = 1960,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 14,
                            Price = 9.99m,
                            PublicationYear = 1925,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 2,
                            Price = 8.99m,
                            PublicationYear = 1813,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 14,
                            Price = 11.99m,
                            PublicationYear = 1951,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 4,
                            Price = 15.99m,
                            PublicationYear = 1997,
                            Title = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 4,
                            Price = 18.99m,
                            PublicationYear = 1954,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 4,
                            Price = 14.99m,
                            PublicationYear = 1937,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 14,
                            Price = 10.99m,
                            PublicationYear = 1945,
                            Title = "Animal Farm"
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 4,
                            Price = 17.99m,
                            PublicationYear = 1950,
                            Title = "The Chronicles of Narnia"
                        },
                        new
                        {
                            Id = 11,
                            GenreId = 1,
                            Price = 13.99m,
                            PublicationYear = 2003,
                            Title = "The Da Vinci Code"
                        },
                        new
                        {
                            Id = 12,
                            GenreId = 21,
                            Price = 11.99m,
                            PublicationYear = 1988,
                            Title = "The Alchemist"
                        },
                        new
                        {
                            Id = 13,
                            GenreId = 15,
                            Price = 14.99m,
                            PublicationYear = 2005,
                            Title = "The Girl with the Dragon Tattoo"
                        },
                        new
                        {
                            Id = 14,
                            GenreId = 15,
                            Price = 12.99m,
                            PublicationYear = 2012,
                            Title = "Gone Girl"
                        },
                        new
                        {
                            Id = 15,
                            GenreId = 16,
                            Price = 10.99m,
                            PublicationYear = 2008,
                            Title = "The Hunger Games"
                        },
                        new
                        {
                            Id = 16,
                            GenreId = 4,
                            Price = 9.99m,
                            PublicationYear = 1979,
                            Title = "The Hitchhiker's Guide to the Galaxy"
                        },
                        new
                        {
                            Id = 17,
                            GenreId = 2,
                            Price = 8.99m,
                            PublicationYear = 1847,
                            Title = "Jane Eyre"
                        },
                        new
                        {
                            Id = 18,
                            GenreId = 24,
                            Price = 12.99m,
                            PublicationYear = 1932,
                            Title = "Brave New World"
                        },
                        new
                        {
                            Id = 19,
                            GenreId = 4,
                            Price = 15.99m,
                            PublicationYear = 1851,
                            Title = "Moby-Dick"
                        },
                        new
                        {
                            Id = 20,
                            GenreId = 4,
                            Price = 20.99m,
                            PublicationYear = 1996,
                            Title = "A Game of Thrones"
                        },
                        new
                        {
                            Id = 21,
                            GenreId = 24,
                            Price = 11.99m,
                            PublicationYear = 2006,
                            Title = "The Road"
                        },
                        new
                        {
                            Id = 22,
                            GenreId = 24,
                            Price = 13.99m,
                            PublicationYear = 2003,
                            Title = "The Kite Runner"
                        },
                        new
                        {
                            Id = 23,
                            GenreId = 2,
                            Price = 10.99m,
                            PublicationYear = 1847,
                            Title = "Wuthering Heights"
                        },
                        new
                        {
                            Id = 24,
                            GenreId = 15,
                            Price = 14.99m,
                            PublicationYear = 1866,
                            Title = "Crime and Punishment"
                        },
                        new
                        {
                            Id = 25,
                            GenreId = 14,
                            Price = 9.99m,
                            PublicationYear = 1890,
                            Title = "The Picture of Dorian Gray"
                        },
                        new
                        {
                            Id = 26,
                            GenreId = 6,
                            Price = 11.99m,
                            PublicationYear = 1818,
                            Title = "Frankenstein"
                        },
                        new
                        {
                            Id = 27,
                            GenreId = 14,
                            Price = 16.99m,
                            PublicationYear = 1844,
                            Title = "The Count of Monte Cristo"
                        },
                        new
                        {
                            Id = 28,
                            GenreId = 9,
                            Price = 12.99m,
                            PublicationYear = 1963,
                            Title = "The Bell Jar"
                        },
                        new
                        {
                            Id = 29,
                            GenreId = 6,
                            Price = 13.99m,
                            PublicationYear = 1977,
                            Title = "The Shining"
                        },
                        new
                        {
                            Id = 30,
                            GenreId = 6,
                            Price = 10.99m,
                            PublicationYear = 1954,
                            Title = "Lord of the Flies"
                        });
                });

            modelBuilder.Entity("BookStore.Domain.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("GenreId");

                    b.ToTable("Genres", (string)null);

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Mystery"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Romance"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Science Fiction"
                        },
                        new
                        {
                            GenreId = 4,
                            GenreName = "Fantasy"
                        },
                        new
                        {
                            GenreId = 5,
                            GenreName = "Thriller"
                        },
                        new
                        {
                            GenreId = 6,
                            GenreName = "Horror"
                        },
                        new
                        {
                            GenreId = 7,
                            GenreName = "Historical Fiction"
                        },
                        new
                        {
                            GenreId = 8,
                            GenreName = "Biography"
                        },
                        new
                        {
                            GenreId = 9,
                            GenreName = "Memoir"
                        },
                        new
                        {
                            GenreId = 10,
                            GenreName = "Self-help"
                        },
                        new
                        {
                            GenreId = 11,
                            GenreName = "Travel"
                        },
                        new
                        {
                            GenreId = 12,
                            GenreName = "Poetry"
                        },
                        new
                        {
                            GenreId = 13,
                            GenreName = "Comedy"
                        },
                        new
                        {
                            GenreId = 14,
                            GenreName = "Drama"
                        },
                        new
                        {
                            GenreId = 15,
                            GenreName = "Crime Fiction"
                        },
                        new
                        {
                            GenreId = 16,
                            GenreName = "Action and Adventure"
                        },
                        new
                        {
                            GenreId = 17,
                            GenreName = "Children's"
                        },
                        new
                        {
                            GenreId = 18,
                            GenreName = "Young Adult"
                        },
                        new
                        {
                            GenreId = 19,
                            GenreName = "Paranormal"
                        },
                        new
                        {
                            GenreId = 20,
                            GenreName = "Urban Fantasy"
                        },
                        new
                        {
                            GenreId = 21,
                            GenreName = "Non-fiction"
                        },
                        new
                        {
                            GenreId = 22,
                            GenreName = "Satire"
                        },
                        new
                        {
                            GenreId = 23,
                            GenreName = "Western"
                        },
                        new
                        {
                            GenreId = 24,
                            GenreName = "Dystopian"
                        },
                        new
                        {
                            GenreId = 25,
                            GenreName = "Fairy Tale"
                        },
                        new
                        {
                            GenreId = 26,
                            GenreName = "LGBTQ+"
                        },
                        new
                        {
                            GenreId = 27,
                            GenreName = "War"
                        },
                        new
                        {
                            GenreId = 28,
                            GenreName = "Spiritual"
                        },
                        new
                        {
                            GenreId = 29,
                            GenreName = "Philosophy"
                        },
                        new
                        {
                            GenreId = 30,
                            GenreName = "Classic"
                        });
                });

            modelBuilder.Entity("BookStore.Domain.AuthorBooks", b =>
                {
                    b.HasOne("BookStore.Domain.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Domain.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStore.Domain.Book", b =>
                {
                    b.HasOne("BookStore.Domain.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookStore.Domain.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("BookStore.Domain.Book", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("BookStore.Domain.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
