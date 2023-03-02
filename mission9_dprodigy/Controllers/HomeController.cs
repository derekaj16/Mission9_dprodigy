using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission9_dprodigy.Models;
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

        public IActionResult Index()
        {
            var books = repo.Books.ToList();
            return View(books);
        }

    }
}
