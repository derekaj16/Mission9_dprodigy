using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission9_dprodigy.Infrastructure;
using mission9_dprodigy.Models;

namespace mission9_dprodigy.Pages
{
    public class CartModel : PageModel
    {

        public IBookstoreRepository repo { get; set; }
        public ShoppingCart cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            BookModel book = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
