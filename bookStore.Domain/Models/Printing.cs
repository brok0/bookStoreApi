using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Domain.Models
{
    public class Printing : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
