using bookStore.BusinessLogic.Abstractions;
using bookStore.Domain.Models;
using bookStore.Infractructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bookStore.BusinessLogic.Services
{
    public class AppService : IAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPrintingRepository _printingRepository;
        public AppService(IBookRepository bookRepository, IAuthorRepository authorRepository,IPrintingRepository printingRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _printingRepository = printingRepository;
        }
        
       
        public async Task<Author> AddAuthorAsync(Author author)
        {
            
            var newauthor = _authorRepository.Insert(author);
            await _authorRepository.UnitOfWork.SaveChangesAsync();
            return newauthor;
        }

        public async Task<Book> AddNewBookAsync(Book book)
        {
            var newbook = _bookRepository.Insert(book);
            await _bookRepository.UnitOfWork.SaveChangesAsync();
            return newbook;
        }

        public async Task<Printing> AddPrintingAsync(Printing printing)
        {
            var newprinting = _printingRepository.Insert(printing);
            await _printingRepository.UnitOfWork.SaveChangesAsync();
            return newprinting;
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var deletion = await _authorRepository.GetByIdAsync(id);
            _authorRepository.Delete(deletion);
            await _authorRepository.UnitOfWork.SaveChangesAsync();

        }

        public async Task DeleteBookAsync(int id)
        {
            var deletion = await _bookRepository.GetByIdAsync(id);
            _bookRepository.Delete(deletion);
            await _bookRepository.UnitOfWork.SaveChangesAsync();

        }

        public async Task DeletePrintingAsync(int id)
        {
            var deletion = await _printingRepository.GetByIdAsync(id);
            _printingRepository.Delete(deletion);
            await _printingRepository.UnitOfWork.SaveChangesAsync();

        }

        public async Task<Author> EditAuthorAsync(Author author)
        {
              _authorRepository.Update(author);
           await _authorRepository.UnitOfWork.SaveChangesAsync();
            return author;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorList = new List<Author>(authors);
            return authorList;
            
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            var booksList = new List<Book>(books);
            return booksList;
        }

        public async Task<List<Printing>> GetAllPrintingsAsync()
        {
            var printings = await _printingRepository.GetAllAsync();
            var printList = new List<Printing>(printings);
            return printList;
        
        }

        public async Task<Author> GetOneAuthorAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }

        public async Task<Book> GetOneBookAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
        public async Task <Printing> GetOnePrintingAsync(int id)
        {
            return await _printingRepository.GetByIdAsync(id);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var bookToUpdate = await _bookRepository.GetByIdAsync(book.Id);
            if (bookToUpdate == null)
                throw new Exception("Use Not Found");
            bookToUpdate.Illustrations = book.Illustrations;
            bookToUpdate.Image = book.Image;
            bookToUpdate.Language = book.Language;
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Price = book.Price;
            bookToUpdate.PrintingId = book.PrintingId;
            bookToUpdate.AuthorId = book.AuthorId;
            bookToUpdate.Cover = book.Cover;
            bookToUpdate.Edition = book.Edition;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Year = book.Year;
             _bookRepository.Update(bookToUpdate);
            await _bookRepository.UnitOfWork.SaveChangesAsync();
            return (bookToUpdate);
        }
    }
}
