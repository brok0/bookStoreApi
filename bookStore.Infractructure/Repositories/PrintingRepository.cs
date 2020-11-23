using bookStore.Domain.Models;
using bookStore.Infractructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Infractructure.Repositories
{
    public class PrintingRepository : BaseRepository<Printing,int>,IPrintingRepository
    {
        public override IUnitOfWork UnitOfWork => (BookStoreContext)_context;

        public PrintingRepository(BookStoreContext context) : base (context)
        {

        }
        
    }
}
