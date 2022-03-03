using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;

        public EFCheckoutRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> checkouts => context.Checkouts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if(checkout.CheckoutID == 0)
            {
                context.Checkouts.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
