using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_dprodigy.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; }

        void SavePurchase(Purchase purchase);
    }
}

