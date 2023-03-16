using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission9_dprodigy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models
{
    public class SessionCart : ShoppingCart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        

        public override void AddItem(BookModel book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);
        }
        public override void DeleteItem(BookModel book)
        {
            base.DeleteItem(book);
            Session.SetJson("Cart", this);
        }
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
