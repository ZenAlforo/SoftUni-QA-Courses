using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemoApp.Models.Product;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MVCIntroDemoApp.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 14.99
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Apples",
                Price = 3.99
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Soap",
                Price = 1.49
            }
        };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = _products
                    .Where(p => p.Name
                                    .ToLower()
                                    .Contains(keyword.ToLower()));

                return View(foundProducts);
            }

            return View(_products);
        }

        public IActionResult ById(int id)
        {
            var result = _products.FirstOrDefault(item => item.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            //return Json(_products, options);
            return new JsonResult(_products, options);
        }

        public IActionResult AllAsText()
        {
            var sb = new StringBuilder();
            foreach (var item in _products)
            {
                var itemData = $"Product {item.Id}: {item.Name} - {item.Price} BGN.";
                sb.AppendLine(itemData);
            }

            //return Json(_products, options);
            return Content(sb.ToString(), "text/plain");
        }

        public IActionResult SaveAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _products)
            {
                sb.AppendLine($"Product {item.Id}: {item.Name} - {item.Price:F2} BGN.");
            }

            Response.Headers.Append(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
