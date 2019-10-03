using CodeSquirrel.RecipeApp.Model;
using CodeSquirrel.RecipeApp.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSquirrel.RecipeApp.API
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class RecipeController : Controller
    {
        private readonly IRepositoryService<Recipe> _service;

        public RecipeController(IRepositoryService<Recipe> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Create")]
        public Recipe Create()
        {
            return new Recipe
            {
                UniqueID = Guid.NewGuid(),
                Name = "<Nieuw recept>"
            };
        }

        [HttpPost]
        [Route("Insert")]
        public bool Insert(Recipe recipe)
        {
            return _service.Add(recipe);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update(Recipe recipe)
        {
            return _service.Update(recipe);
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(Guid recipeID)
        {
            return _service.Remove(recipeID);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Recipe> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetByID")]
        public Recipe Get(Guid recipeId)
        {
            return _service.Get(recipeId);
        }
    }
}