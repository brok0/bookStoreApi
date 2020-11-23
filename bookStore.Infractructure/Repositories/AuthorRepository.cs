using bookStore.Domain.Models;
using bookStore.Infractructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Infractructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author, int>, IAuthorRepository
    {
        public override IUnitOfWork UnitOfWork => (BookStoreContext)_context;
        public AuthorRepository(BookStoreContext context) : base(context)
        {

        }
    }
}
