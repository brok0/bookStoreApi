using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApi.Dto
{
    public class BookCreateDto
    { 
        public string Title { get; set; }
        public int AuthorId { get; set; }

        public int Pages { get; set; }

        public string Edition { get; set; }

        public string Illustrations { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public string Language { get; set; }

        public int Year { get; set; }

        public int PrintingId { get; set; }

        public string Image { get; set; }
    }
}
