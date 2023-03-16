using Microsoft.AspNetCore.Mvc;
using mission9_dprodigy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private ShoppingCart cart { get; set; }

        public PurchaseController(IPurchaseRepository temp, ShoppingCart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Cart.Count() == 0)
            {
                ModelState.AddModelError("", "No items in the cart");
            }

            if (ModelState.IsValid)
            {
                purchase.items = cart.Cart.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
