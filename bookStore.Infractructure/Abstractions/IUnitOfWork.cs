using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bookStore.Infractructure.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
