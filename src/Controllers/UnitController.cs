using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSquirrel.RecipeApp.Model;
using CodeSquirrel.RecipeApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeSquirrel.RecipeApp.API.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : Controller
    {
        private readonly IRepositoryService<Unit> _service;

        public UnitController(IRepositoryService<Unit> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Create")]
        public Unit Create()
        {
            return new Unit
            {
                UniqueID = Guid.NewGuid(),
                Type = UnitType.Undefined,
                Value = 0
            };
        }

        [HttpPost]
        [Route("Insert")]
        public bool Insert([FromBody] Unit unit)
        {
            return _service.Add(unit);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] Unit unit)
        {
            return _service.Update(unit);
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(Guid id)
        {
            return _service.Remove(id);
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Unit> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetByID")]
        public Unit GetByID(Guid id)
        {
            return _service.Get(id);
        }

    }
}