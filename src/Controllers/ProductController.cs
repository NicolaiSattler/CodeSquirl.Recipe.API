using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSquirl.RecipeApp.Model;
using CodeSquirl.RecipeApp.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CodeSquirl.RecipeApp.API
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

        [HttpPost]
        public bool New(Product product)
        {
            return _service.Add(product);
        }


        [HttpGet]
        [Route("GetAll")]
        public List<Product> GetAll()
        {
            return _service.GetAll().ToList();

        }
        // // GET api/values
        // [HttpGet]        
        // public string Get(int id)
        // {
        //     return "value";
        // }
        
    }
}