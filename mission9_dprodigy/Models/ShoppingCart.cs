using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Cart { get; set; } = new List<ShoppingCartItem>();

        public void AddItem(BookModel book, int qty)
        {
            ShoppingCartItem Item = Cart
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (Item == null)
            {
                Cart.Add(new ShoppingCartItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                Item.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Cart.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }
    public class ShoppingCartItem
    {
        public int ItemId { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}
