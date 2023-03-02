using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext bookContext { get; set; }

        public EFBookstoreRepository (BookstoreContext context)
        {
            bookContext = context;
        }
        public IQueryable<BookModel> Books => bookContext.Books;
    }
}
