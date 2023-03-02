using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<BookModel> Books { get; set; }
        public PageInfo pageInfo { get; set; }

    }
}
