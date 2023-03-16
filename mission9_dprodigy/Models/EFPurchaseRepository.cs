using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext purchaseContext { get; set; }

        public EFPurchaseRepository(BookstoreContext context)
        {
            purchaseContext = context;
        }

        public IQueryable<Purchase> Purchases => purchaseContext.Purchases.Include(x => x.items).ThenInclude(x => x.Book);

        public void SavePurchase(Purchase purchase)
        {
            purchaseContext.AttachRange(purchase.items.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                purchaseContext.Purchases.Add(purchase);
            }

            purchaseContext.SaveChanges();
        }
        

    }
}
