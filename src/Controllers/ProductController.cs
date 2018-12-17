using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSquirl.RecipeApp.Model;
using CodeSquirl.RecipeApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CodeSquirl.RecipeApp.API
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IRepositoryService<Product> _service;

        public ProductController(IRepositoryService<Product> service)
        {
            _service = service;
        }


        // GET api/values
        [HttpGet]        
        public string Get(int id)
        {
            return "value";
        }
    }
}