﻿using BookStore.Application.Specifications.Features.Book;
using BookStore.Domain;

namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        bool Exists(int bookId);
        Task<IEnumerable<Book>> GetAllWithSpecifications(GetAllBooksWithGenreAndAuthorsSpecification spec);
        Task<Book> GetBookByIdWithSpecification(GetBookByIdWithDetailsSpecification spec);
        Task<IEnumerable<Book>> SearchBooksWithSpecification(SearchBooksSpecification spec);
    }
}
