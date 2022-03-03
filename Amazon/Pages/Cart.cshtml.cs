using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amazon.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IBookstoreRepository temp, Cart c)
        {
            cart = c;
            repo = temp;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(b => b.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
