using Microsoft.AspNetCore.Mvc;
using TvcLesson05ViewComponents.Models;

namespace TvcLesson05ViewComponents.ViewComponents
{
    public class TvcCategoryViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(bool? active)
        {
            var categories = new List<TvcCategory>
            {
                new TvcCategory { CategoryId = 1, CategoryName = "Electronics", IsActive = true },
                new TvcCategory { CategoryId = 2, CategoryName = "Books", IsActive = true },
                new TvcCategory { CategoryId = 3, CategoryName = "Clothing", IsActive = false },
                new TvcCategory { CategoryId = 4, CategoryName = "Home & Kitchen", IsActive = true },
                new TvcCategory { CategoryId = 5, CategoryName = "Sports & Outdoors", IsActive = true },
                new TvcCategory { CategoryId = 6, CategoryName = "Toys & Games", IsActive = false },
            };
            active = active ?? true;
                        
            categories = categories.Where(c => c.IsActive==active.Value).ToList();

            return View(categories);
        }    
    }
}
