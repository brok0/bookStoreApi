using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Domain.Models
{
    public class Book : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  int AuthorId { get; set; }
        public Author author { get; set; }

        public int Pages { get; set; }

        public string Edition { get; set; }

        public string Illustrations { get; set; }

        public string Cover { get; set; } 

        public decimal Price { get; set; }

        public string Language { get; set; }

        public int Year { get; set; }
        
        public int PrintingId { get; set; }

        public Printing printing { get; set; }

        public byte [] Image { get; set; }
    }
}
