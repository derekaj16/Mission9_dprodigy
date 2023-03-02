using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<BookModel> Books { get; }
    }
}
