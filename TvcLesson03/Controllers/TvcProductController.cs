using Microsoft.AspNetCore.Mvc;
using TvcLesson03.Models;

namespace TvcLesson03.Controllers
{
    public class TvcProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.product = "Chuyển product thông qua  ViewBag";
            ViewData["productVD"] = "Chuyển product thông qua  ViewData";
            TempData["productTD"] = "Chuyển dữ liệu product thông qua TempData";
            return View();
        }

        public IActionResult GetAllProduct()
        {
            ViewBag.hello = "Hello, Chung Trịnh";
            // Tạo mock data
            TvcProduct tvcProduct = new TvcProduct()
            {
                productId = 1,
                productName="Iphone",
                price=1200,
                quantity=100
            };

            ViewData["tvcProduct"] = tvcProduct;
            var products = new List<TvcProduct>
            {
                new TvcProduct
                {
                    productId = 1,
                    productName = "Laptop Dell Inspiron 15",
                    price = 18500000,
                    quantity = 10
                },
                new TvcProduct
                {
                    productId = 2,
                    productName = "Laptop HP Pavilion 14",
                    price = 16900000,
                    quantity = 8
                },
                new TvcProduct
                {
                    productId = 3,
                    productName = "MacBook Air M2",
                    price = 24900000,
                    quantity = 5
                },
                new TvcProduct
                {
                    productId = 4,
                    productName = "iPhone 15",
                    price = 18900000,
                    quantity = 15
                },
                new TvcProduct
                {
                    productId = 5,
                    productName = "Samsung Galaxy S24",
                    price = 20900000,
                    quantity = 12
                },
                new TvcProduct
                {
                    productId = 6,
                    productName = "Tai nghe Sony WH-1000XM5",
                    price = 7990000,
                    quantity = 7
                },
                new TvcProduct
                {
                    productId = 7,
                    productName = "Chuột Logitech MX Master 3S",
                    price = 2290000,
                    quantity = 20
                },
                new TvcProduct
                {
                    productId = 8,
                    productName = "Bàn phím cơ Keychron K2",
                    price = 1890000,
                    quantity = 18
                },
                new TvcProduct
                {
                    productId = 9,
                    productName = "Màn hình LG UltraGear 27",
                    price = 6990000,
                    quantity = 6
                },
                new TvcProduct
                {
                    productId = 10,
                    productName = "Ổ cứng SSD Samsung 1TB",
                    price = 2490000,
                    quantity = 25
                }
            };

            ViewData["list-product"] = products;
            return View("ListProduct");
        }
    }
}
