using System;
using System.Linq;

namespace Amazon.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get;  }
    }
}
