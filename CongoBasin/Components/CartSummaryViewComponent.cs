using CongoBasin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CongoBasin.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart temp)
        {
            cart = temp;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
