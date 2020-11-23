using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Domain.Models
{
    public class Author : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Biography { get; set; }

        public byte [] Image { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
