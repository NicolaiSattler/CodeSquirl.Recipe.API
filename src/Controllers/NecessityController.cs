using System;
using System.Collections.Generic;
using System.Linq;
using CodeSquirrel.RecipeApp.Model;
using CodeSquirrel.RecipeApp.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CodeSquirrel.RecipeApp.API
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class NecessityController : Controller
    {
        private readonly IRepositoryService<Necessity> _service;

        public NecessityController(IRepositoryService<Necessity> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Create")]
        public Necessity Create()
        {
            return new Necessity
            {
                UniqueID = Guid.NewGuid(),
                Name = "<new necessity>",
                Description = "",
                Electrical = false
            };
        }

        [HttpPost]
        [Route("Insert")]
        public bool Insert([FromBody] Necessity necessity)
        {
            return _service.Add(necessity);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] Necessity necessity)
        {
            return _service.Update(necessity);
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(Guid id)
        {
            return _service.Remove(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Necessity> GetAll()
        {
            return _service.GetAll().ToList();
        }

        [HttpGet]
        [Route("GetByID")]
        public Necessity GetByID(Guid necessityID)
        {
            return _service.Get(necessityID);
        }
    }
}