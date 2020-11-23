using bookStore.Domain.Models;
using bookStore.Infractructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bookStore.Infractructure.Repositories
{
    public class BookRepository : BaseRepository<Book,int>, IBookRepository
    {
        public override IUnitOfWork UnitOfWork => (BookStoreContext)_context;
        public BookRepository(BookStoreContext context) : base (context)
        {

        }

        /*public async Task<Book> GetByTitle(string title)
        {
            return await _dbSet.(x => x.Title.Equals(title));
        }*/
    }
}
