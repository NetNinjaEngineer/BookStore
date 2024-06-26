﻿using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Book.Requests.Commands;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Commands;
public sealed class DeleteBookCommandHandler(
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(
        DeleteBookCommand request,
        CancellationToken cancellationToken
        )
    {
        var bookEntity = await unitOfWork.BookRepository.GetBookByIdAsync(request.BookId)
                ?? throw new BookNotFoundException($"Book with ID {request.BookId} was not found.");

        unitOfWork.BookRepository.Delete(bookEntity);

        Utility.Utility.DeleteOldBookImage(bookEntity.ImageName!);

        await unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }
}
