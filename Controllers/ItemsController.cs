using Api.DTO;
using Api.Models;
using Api.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IbaseRepository<Item, ItemModel> repo;

        public ItemsController(IbaseRepository<Item , ItemModel> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = repo.GetAll();
            return Ok(items);        
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) 
        {
            var item = repo.GetById(id);    
            return Ok(item);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name) 
        {
            var item = repo.GetByName(name);
            return Ok(item);    
        }

        [HttpPost]
        public IActionResult AddItem([FromForm] ItemModel item) 
        {
            repo.Add(item); 
            return Ok();    
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            repo.DeleteById(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePatch([FromBody] JsonPatchDocument<Item> mod , int id)
        {
            repo.UpdateWithPatch(mod, id);
            return Ok();    
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,[FromForm] ItemModel item)
        {
            repo.Update(id, item);
            return Ok();
        }

    }
}
