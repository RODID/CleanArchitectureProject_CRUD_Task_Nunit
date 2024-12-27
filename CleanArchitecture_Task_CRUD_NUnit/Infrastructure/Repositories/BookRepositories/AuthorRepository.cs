﻿using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealDatabase _realdatabase;

        public AuthorRepository(RealDatabase realdatabase)
        {
            _realdatabase = realdatabase;
        }

        public Task<Author> AddAuthorAsync(Author author)
        {
            _realdatabase.Authors.Add(author);
            _realdatabase.SaveChanges();

            return Task.FromResult(author);
        }

        public async Task<OperationResult<bool>> DeleteAuthorAsync(Guid id)
        {
            var authorToDelete = await _realdatabase.Authors.FindAsync(id);

            if (authorToDelete == null)
            {
                return OperationResult<bool>.Failure("Author not found", "Failed to delete author");
            }

            _realdatabase.Authors.Remove(authorToDelete);
            await _realdatabase.SaveChangesAsync();

            return OperationResult<bool>.Success(true, "Author successfully deleted");
        }

        public async Task<List<Author>> GetAllAuthorAsync()
        {
            return await _realdatabase.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            return await _realdatabase.Authors.FindAsync();
        }

        public Task<Author> UpdateAuthorAsync(Guid id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
