using System;
using System.Collections.Generic;
using System.Linq;
using CodeSquirrel.RecipeApp.Model;
using CodeSquirrel.RecipeApp.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeSquirrel.RecipeApp.API
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class ProductController : Controller
    {
        private readonly IRepositoryService<Product> _service;

        public ProductController(IRepositoryService<Product> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Create")]
        public Product Create()
        {
            return new Product
            {
                UniqueID = Guid.NewGuid(),
                Name = "<new product>",
                Perishable = false,
                Type = ProductType.Undefined
            };
        }
        [HttpPost]
        [Route("Insert")]
        public bool Insert([FromBody] Product product)
        {
            return _service.Add(product);
        }
        
        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] Product product)
        {
            return _service.Update(product);
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(Guid id)
        {
            return _service.Remove(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Product> GetAll()
        {
            return _service.GetAll().ToList();
        }

        [HttpGet]
        [Route("GetByID")]
        public Product GetByID(Guid productID)
        {
            return _service.Get(productID);
        }

        [HttpGet]
        [Route("GetTypes")]
        public IEnumerable<KeyValuePair<int, string>> GetTypes()
        {
            return Enum<ProductType>.ToKeyValuePairCollection();
        }
        
    }
}