using bookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Infractructure.Abstractions
{
    public interface IBookRepository : IRepository<Book,int>
    {
    }
}
