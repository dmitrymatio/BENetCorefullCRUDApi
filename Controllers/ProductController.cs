using AngularFullCRUD.DataHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularFullCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/product
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/product/{id}

        // For example:
        // http://localhost:<port #>/api/product/1

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.Products.FirstOrDefault(t => t.ProduceID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            Product prod = new Product() { Description = product.Description, Price = product.Price };
            _context.Products.Add(prod);
            _context.SaveChanges();
            return new ObjectResult(product);
        }

        [HttpPut]
        [Route("MyEdit")] // Custom route
        public IActionResult GetByParams([FromBody] Product product)
        {
            var item = _context.Products.Where(t => t.ProduceID == product.ProduceID)
                .FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                if (product.Description != "" && product.Price != 0)
                {
                    item.Description = product.Description;
                    item.Price = product.Price;
                }
                else if (product.Description != "" || product.Price != 0)
                {
                    item.Description = product.Description == "" ? item.Description : product.Description;
                    item.Price = product.Price == 0 ? item.Price : product.Price;
                }
                else
                {
                    item.Description = item.Description;
                    item.Price = item.Price;
                }


                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Products.Where(t => t.ProduceID == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _context.Products.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }

        [HttpGet]
        [Route("GetFirstLast")]
        public IActionResult GetFirstLast()
        {
            dynamic dynamicObj = new { FirstName = "Dmitry", LastName = "Matiouchenko" };
            return new ObjectResult(dynamicObj);
        }
    }

}
