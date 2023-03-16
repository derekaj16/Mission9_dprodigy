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

        public CartModel(IBookstoreRepository temp, ShoppingCart c)
        {
            repo = temp;
            cart = c;

        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            BookModel book = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            cart.AddItem(book, 1);

            foreach (ShoppingCartItem item in cart.Cart)
            {
                Console.WriteLine(item.Book.Title);
            }
           


            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.DeleteItem(cart.Cart.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
