using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongoBasin.Infrastructure;
using CongoBasin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CongoBasin.Pages
{
    public class BuyModel : PageModel
    {
        private ICongoBasinRepository repo { get; set; }

        public BuyModel (ICongoBasinRepository temp, Cart tempCart)
        {
            repo = temp;
            cart = tempCart;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookID, string returnUrl)
        {
            Book book = repo.Books.FirstOrDefault(x => x.BookId == bookID);

   
            cart.AddItem(book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }

        public IActionResult OnPostRemove (int bookID, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookID).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
