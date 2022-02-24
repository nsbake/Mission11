using System;
using System.Linq;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var types = repo.Books.Select(x => x.Category).Distinct().OrderBy(x => x);

            return View(types);
        }
    }
}
