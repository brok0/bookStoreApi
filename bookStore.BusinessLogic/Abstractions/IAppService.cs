using bookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bookStore.BusinessLogic.Abstractions
{
    public interface IAppService
    {
        Task<Book> AddNewBookAsync(Book book);

        Task DeleteBookAsync(int id);
        Task<Book> UpdateBookAsync(Book book);

        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetOneBookAsync(int id);

        Task<Author> GetOneAuthorAsync(int id);
        Task<Printing> GetOnePrintingAsync(int id);

        Task<List<Author>> GetAllAuthorsAsync();

        Task<Author> AddAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);

        Task<Author> EditAuthorAsync(Author author);

        Task<Printing> AddPrintingAsync(Printing printing);

        Task DeletePrintingAsync(int id);

        Task<List<Printing>> GetAllPrintingsAsync();

         
    }
}
