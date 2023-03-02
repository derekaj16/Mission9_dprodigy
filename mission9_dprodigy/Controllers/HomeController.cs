using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission9_dprodigy.Models;
using mission9_dprodigy.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(t => t.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                pageInfo = new PageInfo
                {
                    currentPage = pageNum,
                    totalNumBooks = repo.Books.Count(),
                    booksPerPage = pageSize
                }
            };

           
            return View(x);
        }

    }
}
