using System;
using System.Collections.Generic;
using System.Text;

namespace bookStore.Domain
{
    
        public interface IEntity<T>
        {
            T Id { get; set; }
        }
    
}
