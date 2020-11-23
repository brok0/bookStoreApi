﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApi.Dto
{
    public class AuthorReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Biography { get; set; }

        public byte[] Image { get; set; }
        
    }
}
