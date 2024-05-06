﻿using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.Dtos.Book.Validators;
using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Book.Requests.Commands;
using FluentValidation;
using MediatR;
using System.Text.Json;

namespace BookStore.Application.UseCases.Book.Handlers.Commands;
public sealed class CreateBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    )
    : IRequestHandler<CreateBookCommand, BookForListDto>
{
    public async Task<BookForListDto> Handle(
        CreateBookCommand request,
        CancellationToken cancellationToken
        )
    {
        try
        {
            await new BookForCreationDtoValidator()
                .ValidateAndThrowAsync(request.BookForCreationDto, cancellationToken);
        }
        catch (ValidationException ex)
        {
            var validationErrors = ex.Errors.Select(e => new
            {
                Property = e.PropertyName,
                Error = e.ErrorMessage,
                Severity = e.Severity.ToString()
            });

            var jsonErrors = JsonSerializer.Serialize(validationErrors, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            throw new ValidationException($"Errors: {jsonErrors}");
        }

        var authorExists = unitOfWork
            .AuthorRepository
            .AuthorExists(request.BookForCreationDto.AuthorId);

        if (!authorExists)
            throw new AuthorNotFoundException($"Author with ID {request.BookForCreationDto.AuthorId} not found.");

        var genreExists = unitOfWork
            .GenreRepository
            .GenreExists(request.BookForCreationDto.GenreId);

        if (!genreExists)
            throw new GenreNotFoundException($"Genre with ID {request.BookForCreationDto.GenreId} not found.");

        var (created, uniqueImageName) = Utility.Utility
                        .UploadImage(request.BookForCreationDto.Image, "Books");

        if (!created)
            throw new ImageUploadFailedException("Failed to upload book image.");

        var bookForCreation = mapper.Map<Domain.Book>(request.BookForCreationDto);
        bookForCreation.ImageName = uniqueImageName;
        bookForCreation.GenreId = request.BookForCreationDto.GenreId;

        var createdEntity = unitOfWork.BookRepository.Create(bookForCreation);
        await unitOfWork.SaveChangesAsync();

        unitOfWork.AuthorBooksRepository.Create(new Domain.AuthorBooks
        {
            AuthorId = request.BookForCreationDto.AuthorId,
            BookId = createdEntity.Id
        });

        await unitOfWork.SaveChangesAsync();

        return mapper.Map<BookForListDto>(createdEntity);
    }
}