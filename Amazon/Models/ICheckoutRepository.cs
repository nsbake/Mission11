using System;
using System.Linq;

namespace Amazon.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> checkouts { get; }

        void SaveCheckout(Checkout checkout);
    }
}
