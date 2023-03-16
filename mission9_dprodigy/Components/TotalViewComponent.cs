using Microsoft.AspNetCore.Mvc;
using mission9_dprodigy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Components
{
    public class TotalViewComponent : ViewComponent
    {
        public ShoppingCart cart { get; set; }
        public TotalViewComponent(ShoppingCart c)
        {
            cart = c;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Total = cart.CalculateTotal();
            ViewBag.Items = cart.Cart.Sum(x => x.Quantity);

            return View();
        }
    }
}
